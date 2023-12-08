#include "cryptopp/rsa.h"
using CryptoPP::RSA;
using CryptoPP::InvertibleRSAFunction;
using CryptoPP::RSAES_OAEP_SHA_Encryptor;
using CryptoPP::RSAES_OAEP_SHA_Decryptor;

#include "cryptopp/base64.h"
using CryptoPP::Base64Encoder;
#include "cryptopp/filters.h"
using CryptoPP::StringSink;
using CryptoPP::StringSource;

#include "cryptopp/files.h"
using CryptoPP::FileSink;
using CryptoPP::FileSource;

#include "cryptopp/osrng.h"
using CryptoPP::AutoSeededRandomPool;

//#include "cryptlib.h"
//using CryptoPP::Exception;
//using CryptoPP::DecodingResult;

// work with queue of byte
#include "cryptopp/queue.h"
using CryptoPP::ByteQueue;
using CryptoPP::BufferedTransformation;
#include <string>
using std::string;

#include <exception>
using std::exception;
#include "cryptopp/pem.h"

//c++ library
#include <iostream>
#include <windows.h>

using std::cout;
using std::cerr;
using std::endl;
using namespace std;
// using namespace CryptoPP;
#include <assert.h>
#include <chrono>
// Def function
void Save(const char* filename, const BufferedTransformation& bt);
void Load(const char* filename, BufferedTransformation& bt);
void SavePublicKey(const char* filename, const RSA::PublicKey& key);
void SavePrivateKey(const char* filename, const RSA::PrivateKey& key);
void LoadPublicKey(const char* filename, RSA::PublicKey& key);
void LoadPrivateKey(const char* filename, RSA::PrivateKey& key);

extern "C" {
    __declspec(dllexport) double key_gen(const char* filePriv, const char* filePub, int choice);
}

double key_gen(const char* filePriv, const char* filePub, int choice)
{
    // define random generator
    double time = 0;
    if (choice == 1) // save to ber
    {
        auto start = std::chrono::high_resolution_clock::now();
        //
        // define random generator

        AutoSeededRandomPool rng;
        InvertibleRSAFunction parameters;
        parameters.GenerateRandomWithKeySize(rng, 3072);

        RSA::PrivateKey priv(parameters);
        RSA::PublicKey pub(parameters);
        SavePrivateKey(filePriv, priv); //Encode
        SavePublicKey(filePub, pub);
        //
        auto end = std::chrono::high_resolution_clock::now();
        auto duration = std::chrono::duration_cast<std::chrono::microseconds>(end - start).count();
        time = static_cast<double>(duration);
    }
    else if (choice == 2) //save to PEM
    {
        auto start = std::chrono::high_resolution_clock::now();
        //
        // define random generator

        AutoSeededRandomPool rng;
        InvertibleRSAFunction parameters;
        parameters.GenerateRandomWithKeySize(rng, 3072);

        RSA::PrivateKey priv(parameters);
        RSA::PublicKey pub(parameters);
        CryptoPP::FileSink public_key(filePub, true);
        CryptoPP::PEM_Save(public_key, pub);
        CryptoPP::FileSink private_key(filePriv, true);
        CryptoPP::PEM_Save(private_key, priv);
        //
        auto end = std::chrono::high_resolution_clock::now();
        auto duration = std::chrono::duration_cast<std::chrono::milliseconds>(end - start).count();
        time = static_cast<double>(duration);
    }
    return time;
}


void Save(const char* filename, const BufferedTransformation& bt)
{
    FileSink file(filename);

    bt.CopyTo(file);
    file.MessageEnd();
}

void Load(const char* filename, BufferedTransformation& bt)
{
    FileSource file(filename, true /*pumpAll*/);

    file.TransferTo(bt);
    bt.MessageEnd();
}
// save publickey into binary format
void SavePublicKey(const char* filename, const RSA::PublicKey& key)
{
    // http://www.cryptopp.com/docs/ref/class_byte_queue.html
    ByteQueue queue;
    key.DEREncodePublicKey(queue);

    Save(filename, queue);
}
// save private key into binary format
void SavePrivateKey(const char* filename, const RSA::PrivateKey& key)
{
    ByteQueue queue;
    key.DEREncodePrivateKey(queue);

    Save(filename, queue);
}
// load private key in binary format
void LoadPrivateKey(const char* filename, RSA::PrivateKey& key)
{
    // http://www.cryptopp.com/docs/ref/class_byte_queue.html
    ByteQueue queue;

    Load(filename, queue);
    key.BERDecodePrivateKey(queue, false /*optParams*/, queue.MaxRetrievable());
}
// load public key in binary format  

void LoadPublicKey(const char* filename, RSA::PublicKey& key)
{
    // http://www.cryptopp.com/docs/ref/class_byte_queue.html
    ByteQueue queue;

    Load(filename, queue);
    key.BERDecodePublicKey(queue, false /*optParams*/, queue.MaxRetrievable());
}