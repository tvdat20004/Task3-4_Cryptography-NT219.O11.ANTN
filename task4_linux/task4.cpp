// ECDSA.KeyGen.cpp : Defines the entry point for the console application.
//

// #include "stdafx.h"

#include <assert.h>
#include <fstream>
using std::fstream;
#include <iostream>
using std::cerr;
using std::cout;
using std::endl;
#include <string>
using std::string;

#include "cryptopp/pem.h"
#include "cryptopp/pem_common.h"
#include "cryptopp/osrng.h"
// using CryptoPP::AutoSeededX917RNG;
using CryptoPP::AutoSeededRandomPool;
#include "cryptopp/hex.h"
using CryptoPP::HexDecoder;
using CryptoPP::HexEncoder;

#include "cryptopp/aes.h"
using CryptoPP::AES;

#include "cryptopp/integer.h"
using CryptoPP::Integer;

#include "cryptopp/sha.h"
using CryptoPP::SHA1;
#include <chrono>
#include "cryptopp/filters.h"
using CryptoPP::StringSource;
using CryptoPP::StringSink;
using CryptoPP::ArraySink;
using CryptoPP::SignerFilter;
using CryptoPP::SignatureVerificationFilter;

#include "cryptopp/files.h"
using CryptoPP::FileSource;
using CryptoPP::FileSink;

#include "cryptopp/eccrypto.h"
using CryptoPP::ECDSA;
using CryptoPP::ECP;
using CryptoPP::DL_GroupParameters_EC;

#if _MSC_VER <= 1200 // VS 6.0

#endif

#include "cryptopp/oids.h"
using CryptoPP::OID;

bool GeneratePrivateKey( const OID& oid, ECDSA<ECP, SHA1>::PrivateKey& key );
bool GeneratePublicKey( const ECDSA<ECP, SHA1>::PrivateKey& privateKey, ECDSA<ECP, SHA1>::PublicKey& publicKey );

void SavePrivateKey( const string& filename, const ECDSA<ECP, SHA1>::PrivateKey& key );
void SavePublicKey( const string& filename, const ECDSA<ECP, SHA1>::PublicKey& key );
void LoadPrivateKey( const string& filename, ECDSA<ECP, SHA1>::PrivateKey& key );
void LoadPublicKey( const string& filename, ECDSA<ECP, SHA1>::PublicKey& key );

bool SignMessage( const ECDSA<ECP, SHA1>::PrivateKey& key, const string& message, string& signature );
bool VerifyMessage( const ECDSA<ECP, SHA1>::PublicKey& key, const string& message, const string& signature );

int detect_pem_pubkey(string filename) 
{
    std::ifstream file(filename);
    if (!file.is_open())
    {
        return 2;
    }
    string line;
    getline(file, line);

    if (line.find("-----BEGIN PUBLIC KEY-----") == std::string::npos)
    {
        return 0;
    }
    while (getline(file, line))
    {
        if (line.find("-----END PUBLIC KEY-----") != std::string::npos) {
            return 1;
        }
    }

    return 0;
}
int detect_pem_privkey(string filename) {
    std::ifstream file(filename);
    if (!file.is_open())
    {
        return 2;
    }
    string line;
    getline(file, line);
    if (line.find("-----BEGIN EC PRIVATE KEY-----") == std::string::npos)
    {
        return 0;
    }
    while (getline(file, line)) {
        if (line.find("-----END EC PRIVATE KEY-----") != std::string::npos) {
            return 1;
        }
    }
    return 0;
}
int main(int argc, char* argv[])
{
    // Scratch res
    #ifdef __linux__
    std::locale::global(std::locale("C.UTF-8"));
    #endif
    #ifdef _WIN32
    // Set console code page to UTF-8 on Windows
    SetConsoleOutputCP(CP_UTF8);
    SetConsoleCP(CP_UTF8);
    #endif
    int choose;
    if (argc == 1)
    {
        cerr << "Usage: task4 <mode>" << endl;
        cerr << "Mode: keygen, sign, verify" << endl;
        return 1;
    }
    if (string(argv[1]) == "keygen")
        choose = 1;
    else if (string(argv[1]) == "sign")
        choose = 2;
    else if (string(argv[1]) == "verify")
        choose = 3;
    else 
    {
        cerr << "Invalid mode:" << argv[1] << endl;
        return 1;
    }
    switch (choose)
    {
    case 1: // key gen
    {
        if (argc != 5)
        {
            cerr << "Usage: task4 keygen <Private_key_filename> <Public_key_filename> <file_type>" << endl;
            cerr << "Supported file type: ber, pem." << endl;
            return 1;
        }
        string filePriv = string(argv[2]),filePub = string(argv[3]),fileType = string(argv[4]);

        if (fileType == "ber")
        {
            auto start = std::chrono::high_resolution_clock::now();
            //
            ECDSA<ECP, SHA1>::PrivateKey privateKey;
            ECDSA<ECP, SHA1>::PublicKey publicKey;
            bool result;
            result = GeneratePrivateKey(CryptoPP::ASN1::secp160r1(), privateKey);
            assert( true == result );
            if( !result ) { return -1; }

            result = GeneratePublicKey( privateKey, publicKey );
            assert( true == result );
            if( !result ) { return -2; }
            SavePrivateKey( filePriv, privateKey );
            SavePublicKey( filePub, publicKey );
            //
            auto end = std::chrono::high_resolution_clock::now();
            auto duration = std::chrono::duration_cast<std::chrono::milliseconds>(end - start).count();
            cout << "Successfully save ECDSA keys.\n";
            cout << "Time for key generation: " << static_cast<double>(duration) << " microsecond" << endl;
        }
        else if (fileType == "pem")
        {
            auto start = std::chrono::high_resolution_clock::now();
            //
            ECDSA<ECP, SHA1>::PrivateKey privateKey;
            ECDSA<ECP, SHA1>::PublicKey publicKey;
            bool result;
            result = GeneratePrivateKey(CryptoPP::ASN1::secp160r1(), privateKey);
            assert( true == result );
            if( !result ) { return -1; }

            result = GeneratePublicKey( privateKey, publicKey );
            assert( true == result );
            if( !result ) { return -2; }
            FileSink pub(filePub.data(), true);
            PEM_Save(pub, publicKey);
            FileSink priv(filePriv.data(), true);
            PEM_Save(priv, privateKey);
            //
            auto end = std::chrono::high_resolution_clock::now();
            auto duration = std::chrono::duration_cast<std::chrono::milliseconds>(end - start).count();
            cout << "Successfully save ECDSA keys.\n";
            cout << "Time for key generation: " << static_cast<double>(duration) << " microsecond" << endl;
        }
        else 
        {
            cerr << "Invalid file type!!!" << endl;
            return 1;
        }
        break;
    }
    case 2: // sign
    {
        if (argc != 5)
        {
            cerr << "Usage: task4 sign <Private_key_file> <file/screen> <message>/<message_file_path>"<<endl;
            cerr << "Example: task4 sign priv.pem file mess.txt"<<endl;
            return 1;
        }
        int enter;
        AutoSeededRandomPool prng;
        ECDSA<ECP, SHA1>::PrivateKey key;
        string filePrivKey = string(argv[2]);
        if (string(argv[3]) == "file")
        {
            enter = 2;
        }
        else if (string(argv[3]) == "screen")
        {
            enter = 1;
        }
        else
        {
            cerr << "Invalid option!!\n";
            return 1;
        }
        int fileType = detect_pem_privkey(filePrivKey);
        if (fileType == 0)
            LoadPrivateKey(filePrivKey, key);
        else if (fileType == 1)
        {
            FileSource fs(filePrivKey.data(), true);
            PEM_Load(fs, key);
        }
        else 
        {
            cerr << "Fail to load ECDSA key!!!" << endl;
            return 1;
        }
        cout << "Successfully load ECDSA keys" << endl;
        string mess, sign;
        switch (enter)
        {
            case 1:
            {
                // enter plaintext from screen
                mess = string(argv[4]);
                break;
            }
            case 2:
            {
                // enter plaintext from file
                string filename = string(argv[4]);
                FileSource(filename.data(), true, new StringSink(mess));
                break;
            }
        }
        auto start = std::chrono::high_resolution_clock::now();
        //
        // StringSource(mess, true,
        //     new SignerFilter(prng,
        //         ECDSA<ECP, SHA1>::Signer(key),
        //         new StringSink(sign)
        //     ) // SignerFilter
        // ); // StringSource
        SignMessage(key, mess, sign);
        //
        auto end = std::chrono::high_resolution_clock::now();
        auto duration = std::chrono::duration_cast<std::chrono::microseconds>(end - start).count();
        cout << "Successfully sign message.\n";
        cout << "Time for signing: " << static_cast<double>(duration) << " microsecond\n";
        //  Convert output into hexadecimal
        string signHex;
        StringSource(sign, true, new HexEncoder(new StringSink(signHex)));
        cout << "Signature (hex):" << signHex << endl;
        break;
    }
    case 3:
    {
        bool result = true;
        if (argc != 5)
        {
            cerr << "Usage: task4 verify <Public_key_file> <file/screen> <message>/<message file path>"<<endl;
            cerr << "Example: task4 verify pub.pem file mess.txt"<<endl;
            return 1;
        }
        int enter;
        AutoSeededRandomPool prng;
        ECDSA<ECP, SHA1>::PublicKey key;
        string filePubKey = string(argv[2]);
        if (string(argv[3]) == "file")
        {
            enter = 2;
        }
        else if (string(argv[3]) == "screen")
        {
            enter = 1;
        }
        else
        {
            cerr << "Invalid option!!\n";
            return 1;
        }
        int fileType = detect_pem_pubkey(filePubKey);
        if (fileType == 0)
            LoadPublicKey(filePubKey, key);
        else if (fileType == 1)
        {
            FileSource fs(filePubKey.data(), true);
            PEM_Load(fs, key);
        }
        else 
        {
            cerr << "Fail to load ECDSA key!!!" << endl;
            return 1;
        }
        cout << "Successfully load ECDSA keys" << endl;
        string mess, sign, signHex;
        cout << "Enter signature to verify: ";
        std::cin >> signHex;
        
        StringSource(signHex, true, new HexDecoder(new StringSink(sign)));
        // cout << sign << endl;
        switch (enter)
        {
            case 1:
            {
                // enter plaintext from screen
                mess = string(argv[4]);
                break;
            }
            case 2:
            {
                // enter plaintext from file
                string filename = string(argv[4]);
                FileSource(filename.data(), true, new StringSink(mess));
                break;
            }
        }
        auto start = std::chrono::high_resolution_clock::now();
        //
        result = VerifyMessage(key, mess, sign );
        //
        auto end = std::chrono::high_resolution_clock::now();
        auto duration = std::chrono::duration_cast<std::chrono::microseconds>(end - start).count();
        // cout << "Successfully verify message.\n";
        cout << "Time for verifying: " << static_cast<double>(duration) << " microsecond\n";
        
        if (result)
        {
            cout << "Verify successfully!!!" << endl;
        }
        else
            cout << "Verify fail!!!" << endl;
        break;
    }
    default:
    {
        cerr << "Invalid option!!!" << endl;
        return 1;
    }
    }
    return 0;
}

bool GeneratePrivateKey( const OID& oid, ECDSA<ECP, SHA1>::PrivateKey& key )
{
    AutoSeededRandomPool prng;

    key.Initialize( prng, oid );
    assert( key.Validate( prng, 3 ) );
     
    return key.Validate( prng, 3 );
}

bool GeneratePublicKey( const ECDSA<ECP, SHA1>::PrivateKey& privateKey, ECDSA<ECP, SHA1>::PublicKey& publicKey )
{
    AutoSeededRandomPool prng;

    // Sanity check
    assert( privateKey.Validate( prng, 3 ) );

    privateKey.MakePublicKey(publicKey);
    assert( publicKey.Validate( prng, 3 ) );

    return publicKey.Validate( prng, 3 );
}

void SavePrivateKey( const string& filename, const ECDSA<ECP, SHA1>::PrivateKey& key )
{
    key.Save( FileSink( filename.c_str(), true /*binary*/ ).Ref() );
}

void SavePublicKey( const string& filename, const ECDSA<ECP, SHA1>::PublicKey& key )
{   
    key.Save( FileSink( filename.c_str(), true /*binary*/ ).Ref() );
}

void LoadPrivateKey( const string& filename, ECDSA<ECP, SHA1>::PrivateKey& key )
{   
    key.Load( FileSource( filename.c_str(), true /*pump all*/ ).Ref() );
}

void LoadPublicKey( const string& filename, ECDSA<ECP, SHA1>::PublicKey& key )
{
    key.Load( FileSource( filename.c_str(), true /*pump all*/ ).Ref() );
}

bool SignMessage( const ECDSA<ECP, SHA1>::PrivateKey& key, const string& message, string& signature )
{
    AutoSeededRandomPool prng;
    
    signature.erase();    

    StringSource( message, true,
        new SignerFilter( prng,
            ECDSA<ECP,SHA1>::Signer(key),
            new StringSink( signature )
        ) // SignerFilter
    ); // StringSource
    
    return !signature.empty();
}

bool VerifyMessage( const ECDSA<ECP, SHA1>::PublicKey& key, const string& message, const string& signature )
{
    bool result = false;

    StringSource( signature+message, true,
        new SignatureVerificationFilter(
            ECDSA<ECP,SHA1>::Verifier(key),
            new ArraySink( (CryptoPP::byte*)&result, sizeof(result) )
        ) // SignatureVerificationFilter
    );

    return result;
}
