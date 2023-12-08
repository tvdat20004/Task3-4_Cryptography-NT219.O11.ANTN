
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
RSA::PrivateKey privKey;
RSA::PublicKey pubKey;
// Def function
void Encode(const string& filename, const BufferedTransformation& bt);
void Decode(const string& filename, BufferedTransformation& bt);
void EncodePublicKey(const string& filename, const RSA::PublicKey& key);
void EncodePrivateKey(const string& filename, const RSA::PrivateKey& key);
void DecodePublicKey(const string& filename, RSA::PublicKey& key);
void DecodePrivateKey(const string& filename, RSA::PrivateKey& key);

extern "C" {
    __declspec(dllexport) double decrypt(const char* filePriv, int choice, const char* cipher, char* plain, char* popup);
}
void getValue(char* str, int strlen, string result)
{
    result = result.substr(0, strlen);
    copy(result.begin(), result.end(), str);
    str[min(strlen - 1, (int)result.size())] = 0;
}

int detect_pem(const char* filename) {
    ifstream file(filename);
    if (!file.is_open()) 
    {
        return 2;
    }
    string line;
    getline(file, line);
    if (line != "-----BEGIN RSA PRIVATE KEY-----") 
    {
        return 0;
    }
    while (getline(file, line)) {
        if (line == "-----END RSA PRIVATE KEY-----") {
            return 1;
        }
    }
    return 0;
}

double decrypt(const char* filePriv, int choice, const char* cipher, char* plain, char* popup)
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
    RSA::PrivateKey privKey;
    // load RSA private key
    int fileType = detect_pem(filePriv);
    try
    {
        if (fileType == 0)
        {
            DecodePrivateKey(filePriv, privKey);
        }
        else if (fileType == 1)
        {
            FileSource fs(filePriv, true);
            PEM_Load(fs, privKey);
        }
        else
        {
            getValue(popup, MAXLENGTH, "Can't open key file!!!");
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
        FileSource(cipher, true, new HexDecoder(new StringSink(ct)));
    }
    else if (choice == 2)
    {
        StringSource(cipher, true, new HexDecoder(new StringSink(ct)));
    }
    else
    {
        getValue(popup, MAXLENGTH, "Please choose an option!!!");
        return 0;
    }

    auto start = std::chrono::high_resolution_clock::now();
    //
    // Decrypt RSA
    RSAES_OAEP_SHA_Decryptor d(privKey);
    StringSource(ct, true,
        new PK_DecryptorFilter(rng, d,
            new StringSink(pt)
        )
    );
    //
    auto end = std::chrono::high_resolution_clock::now();
    auto duration = std::chrono::duration_cast<std::chrono::microseconds>(end - start).count();
    double time = static_cast<double>(duration);
    
    //return 0;

    if (choice == 1) //  tu file
    {
        StringSource(pt, true, new FileSink("recover.txt"));
        getValue(popup, MAXLENGTH, "Successfully save ciphertext in recover.txt");
    }
    else // tu man hinh
    {
        getValue(popup, MAXLENGTH, "Successfully decrypt RSA.");
        getValue(plain, MAXLENGTH, pt);
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
    // http://www.cryptopp.com/docs/ref/class_byte_queue.html
    ByteQueue queue;

    Decode(filename, queue);
    key.BERDecodePublicKey(queue, false /*optParams*/, queue.MaxRetrievable());
}