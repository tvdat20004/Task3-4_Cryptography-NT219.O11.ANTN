
#include "cryptopp/rsa.h"
using CryptoPP::RSA;
using CryptoPP::InvertibleRSAFunction;
using CryptoPP::RSAES_OAEP_SHA_Encryptor;
using CryptoPP::RSAES_OAEP_SHA_Decryptor;

#include "cryptopp/sha.h"
using CryptoPP::SHA1;
#include "cryptopp/base64.h"
using CryptoPP::Base64Encoder;
#include "cryptopp/filters.h"
using CryptoPP::StringSink;
using CryptoPP::StringSource;
using CryptoPP::PK_EncryptorFilter;
using CryptoPP::PK_DecryptorFilter;

#include "cryptopp/hex.h"
using CryptoPP::HexEncoder;
using CryptoPP::HexDecoder;
#include "cryptopp/files.h"
using CryptoPP::FileSink;
using CryptoPP::FileSource;

#include "cryptopp/osrng.h"
using CryptoPP::AutoSeededRandomPool;

#include "cryptopp/cryptlib.h"
using CryptoPP::Exception;
using CryptoPP::DecodingResult;
#include "cryptopp/pem.h"
// work with queue of byte
// #include "cryptopp/queue.h"
using CryptoPP::ByteQueue;
using CryptoPP::BufferedTransformation;
#include <string>
using std::string;

#include <exception>
using std::exception;

#include <iostream>
#include <windows.h>
#include <fstream>
using namespace std;
// using namespace CryptoPP;
#include <assert.h>

// Def function
void Encode(const string& filename, const BufferedTransformation& bt);
void Decode(const string& filename, BufferedTransformation& bt);
void EncodePublicKey(const string& filename, const RSA::PublicKey& key);
void EncodePrivateKey(const string& filename, const RSA::PrivateKey& key);
void DecodePublicKey(const string& filename, RSA::PublicKey& key);
void DecodePrivateKey(const string& filename, RSA::PrivateKey& key);


extern "C" {
    __declspec(dllexport) double encrypt(const char* filePub, int choice, const char* plain, char* cipher, char* popup);
}

int detect_pem(const char* filename) {
    ifstream file(filename);
    if (!file.is_open())
    {
        return 2;
    }
    string line;
    getline(file, line);
    if (line != "-----BEGIN PUBLIC KEY-----")
    {
        return 0;
    }
    while (getline(file, line)) {
        if (line == "-----END PUBLIC KEY-----") {
            return 1;
        }
    }
    return 0;
}

void getValue(char* str, int strlen, string result) 
{
    result = result.substr(0, strlen);
    copy(result.begin(), result.end(), str);
    str[min(strlen - 1, (int)result.size())] = 0;   
}
double encrypt(const char* filePub, int choice , const char* plain, char* cipher, char* popup)
{
#ifdef __linux__
    std::locale::global(std::locale("C.UTF-8"));
#endif
#ifdef _WIN32
    // Set console code page to UTF-8 on Windows
    SetConsoleOutputCP(CP_UTF8);
    SetConsoleCP(CP_UTF8);
#endif
    const int MAXLENGTH = 3072;
    RSA::PublicKey pubKey;
    // load RSA public key
    int fileType = detect_pem(filePub);
    try
    {
        if (fileType == 0)
        {
            DecodePublicKey(filePub, pubKey);
        }
        else if (fileType == 1)
        {
            FileSource fs(filePub, true);
            PEM_Load(fs, pubKey);
        }
        else
        {
            getValue(popup, MAXLENGTH, "Can't open file key!!!");
            return 0;
        }
    }
    catch (const std::exception&)
    {
        getValue(popup, MAXLENGTH, "Fail to load RSA key!!!");
        return 0;
    }

    AutoSeededRandomPool rng;
    string pt, ct;
    if (choice == 1) // nhap tu file
    {
        FileSource(plain, true, new StringSink(pt));
    }
    else if (choice == 2)
    {
        pt = plain;
    }
    else
    {
        getValue(popup, MAXLENGTH, "Please choose an option!!!");
        return 0;
    }
    
    auto start = std::chrono::high_resolution_clock::now();
    //
    RSAES_OAEP_SHA_Encryptor e(pubKey);
    StringSource(pt, true,
        new PK_EncryptorFilter(rng, e,
            new StringSink(ct)
        ) // PK_EncryptorFilter
    ); // StringSource
    //
    auto end = std::chrono::high_resolution_clock::now();
    auto duration = std::chrono::duration_cast<std::chrono::microseconds>(end - start).count();
    double time = static_cast<double>(duration);
    
    //  Convert output into hexadecimal
    string encoded_hex;
    StringSource(ct, true, new HexEncoder(new StringSink(encoded_hex)));
    if (choice == 1) // tu file
    {
        StringSource(encoded_hex, true, new FileSink("cipher.txt"));
        getValue(popup, MAXLENGTH, "Successfully save ciphertext in cipher.txt");
    }
    else //  tu man hinh
    {
        getValue(popup, MAXLENGTH, "Successfully encrypt RSA.");
        getValue( cipher, MAXLENGTH, encoded_hex);
    }
    return time;
}

void Encode(const string& filename, const BufferedTransformation& bt)
{
    FileSink file(filename.c_str());

    bt.CopyTo(file);
    file.MessageEnd();
}

void Decode(const string& filename, BufferedTransformation& bt)
{
    FileSource file(filename.c_str(), true /*pumpAll*/);

    file.TransferTo(bt);
    bt.MessageEnd();
}
// encode publickey into binary format
void EncodePublicKey(const string& filename, const RSA::PublicKey& key)
{
    // http://www.cryptopp.com/docs/ref/class_byte_queue.html
    ByteQueue queue;
    key.DEREncodePublicKey(queue);

    Encode(filename, queue);
}
// encode private key into binary format
void EncodePrivateKey(const string& filename, const RSA::PrivateKey& key)
{
    ByteQueue queue;
    key.DEREncodePrivateKey(queue);

    Encode(filename, queue);
}
// decode private key in binary format
void DecodePrivateKey(const string& filename, RSA::PrivateKey& key)
{
    // http://www.cryptopp.com/docs/ref/class_byte_queue.html
    ByteQueue queue;

    Decode(filename, queue);
    key.BERDecodePrivateKey(queue, false /*optParams*/, queue.MaxRetrievable());
}
// decode public key in binary format

void DecodePublicKey(const string& filename, RSA::PublicKey& key)
{
    ByteQueue queue;

    Decode(filename, queue);
    key.BERDecodePublicKey(queue, false /*optParams*/, queue.MaxRetrievable());
}