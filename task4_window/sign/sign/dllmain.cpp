// ECDSA.KeyGen.cpp : Defines the entry point for the console application.
//

// #include "stdafx.h"

#include <assert.h>

#include <iostream>
#include <string>
#include <cryptopp/pem.h>
#include <cryptopp/pem_common.h>
using namespace std;
#include "cryptopp/osrng.h"
// using CryptoPP::AutoSeededX917RNG;
using CryptoPP::AutoSeededRandomPool;

#include "cryptopp/aes.h"
using CryptoPP::AES;

#include "cryptopp/integer.h"
using CryptoPP::Integer;

#include "cryptopp/sha.h"
using CryptoPP::SHA1;
#include <cryptopp/hex.h>
using CryptoPP::HexEncoder;
#include "cryptopp/filters.h"
using CryptoPP::StringSource;
using CryptoPP::StringSink;
using CryptoPP::ArraySink;
using CryptoPP::SignerFilter;
using CryptoPP::SignatureVerificationFilter;

#include "cryptopp/files.h"
using CryptoPP::FileSource;
using CryptoPP::FileSink;
#include <cryptopp/hex.h>

#include "cryptopp/eccrypto.h"
using CryptoPP::ECDSA;
using CryptoPP::ECP;
using CryptoPP::DL_GroupParameters_EC;
// #include "cryptopp/pem.h"
#if _MSC_VER <= 1200 // VS 6.0
// using CryptoPP::ECDSA<ECP, SHA1>;
// using CryptoPP::DL_GroupParameters_EC<ECP>;
#endif

#include "cryptopp/oids.h"
using CryptoPP::OID;
#include <windows.h>
#include <fstream>
extern "C" {
    __declspec(dllexport) void SignMessage(const char* fileKey, const char* message, char* signature, char* popup, int choice);
}
int detect_pem(const char* filename) 
{
    ifstream file(filename);
    if (!file.is_open())
    {
        return 2; // error 
    }
    string line;
    getline(file, line);
    if (line != "-----BEGIN EC PRIVATE KEY-----")
    {
        return 0;
    }
    while (getline(file, line)) {
        if (line == "-----END EC PRIVATE KEY-----") {
            return 1; // is PEM
        }
    }
    return 0; // is BER
}
void getValue(char* str, int strlen, string result)
{
    result = result.substr(0, strlen);
    copy(result.begin(), result.end(), str);
    str[min(strlen - 1, (int)result.size())] = 0;
}
void LoadPrivateKey(const char* filename, ECDSA<ECP, SHA1>::PrivateKey& key)
{
    key.Load(FileSource(filename, true /*pump all*/).Ref());
}
void SignMessage(const char* filekey, const char* message, char* signature, char* popup, int choice)
{
#ifdef __linux__
    std::locale::global(std::locale("C.UTF-8"));
#endif
#ifdef _WIN32
    // Set console code page to UTF-8 on Windows
    SetConsoleOutputCP(CP_UTF8);
    SetConsoleCP(CP_UTF8);
#endif

    int MAXLENGTH = 3072;
    AutoSeededRandomPool prng;
    ECDSA<ECP, SHA1>::PrivateKey key;
    try
    {
        int fileType = detect_pem(filekey);
        if (fileType == 1)
        {
            FileSource fs(filekey, true);
            PEM_Load(fs, key);
        }
        else if (fileType == 0)
        {
            LoadPrivateKey(filekey, key);
        }
        else
        {
            getValue(popup, MAXLENGTH, "Can't open file key!!!");
            return;
        }
    }
    catch (const std::exception&)
    {
        getValue(popup, MAXLENGTH, "Fail to load ECDSA key!!!");
        return;
    }
        
    string m;
    if (choice == 1) // from file
    {
        FileSource(message, true, new StringSink(m));
    }
    else if (choice == 2) // from keyboard
    {
        m = message;
    }
    else
    {
        getValue(popup, MAXLENGTH, "Please choose an option!!!");
        return;
    }
    string sign;
    StringSource(m, true,
        new SignerFilter(prng,
            ECDSA<ECP, SHA1>::Signer(key),
            new StringSink(sign)
        ) // SignerFilter
    ); // StringSource
    string signHex;
    StringSource(sign, true, new HexEncoder(new StringSink(signHex)));
    getValue(signature, MAXLENGTH, signHex);
    getValue(popup, MAXLENGTH, "Successfully sign message!!!");
}