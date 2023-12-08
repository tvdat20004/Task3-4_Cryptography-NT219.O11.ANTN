// ECDSA.KeyGen.cpp : Defines the entry point for the console application.
//

// #include "stdafx.h"

#include <assert.h>
#include <fstream>
#include <iostream>
using namespace std;

#include <string>
#include <cryptopp/hex.h>

#include "cryptopp/osrng.h"
// using CryptoPP::AutoSeededX917RNG;
using CryptoPP::AutoSeededRandomPool;

#include "cryptopp/aes.h"
using CryptoPP::AES;
#include "cryptopp/pem.h"
#include "cryptopp/pem_common.h"

#include "cryptopp/integer.h"
using CryptoPP::Integer;

#include "cryptopp/sha.h"
using CryptoPP::SHA1;

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
using CryptoPP::HexEncoder;
using CryptoPP::HexDecoder;

// #include "cryptopp/pem.h"
#if _MSC_VER <= 1200 // VS 6.0
// using CryptoPP::ECDSA<ECP, SHA1>;
// using CryptoPP::DL_GroupParameters_EC<ECP>;
#endif

#include "cryptopp/oids.h"
using CryptoPP::OID;
#include <windows.h>
extern "C" {
    __declspec(dllexport) void VerifyMessage(const char* filePub, int choice, const char* message, const char* signature, char* popup);
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
    if (line != "-----BEGIN PUBLIC KEY-----")
    {
        return 0;
    }
    while (getline(file, line)) {
        if (line == "-----END PUBLIC KEY-----") {
            return 1; // is PEM
        }
    }
    return 0; // is BER
}
void LoadPublicKey(const string& filename, ECDSA<ECP, SHA1>::PublicKey& key)
{
    key.Load(FileSource(filename.c_str(), true /*pump all*/).Ref());
}
void getValue(char* str, int strlen, string result)
{
    result = result.substr(0, strlen);
    copy(result.begin(), result.end(), str);
    str[min(strlen - 1, (int)result.size())] = 0;
}
void VerifyMessage(const char* filePub, int choice, const char* message, const char* signHex, char* popup)
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
    bool result = false;
    ECDSA<ECP, SHA1>::PublicKey key;
    try
    {
        int fileType = detect_pem(filePub);
        if (fileType == 1)
        {
            FileSource fs(filePub, true);
            PEM_Load(fs, key);
        }
        else if (fileType == 0)
        {
            LoadPublicKey(filePub, key);
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
    string signature;
    StringSource(signHex, true, new HexDecoder(new StringSink(signature)));

    StringSource(signature + m, true,
        new SignatureVerificationFilter(
            ECDSA<ECP, SHA1>::Verifier(key),
            new ArraySink((CryptoPP::byte*)&result, sizeof(result))
        ) // SignatureVerificationFilter
    );
    if (result)
    {
        getValue(popup, MAXLENGTH, "Verify successfully!!!");
    }
    else getValue(popup, MAXLENGTH, "Verify fail!!!");
}
