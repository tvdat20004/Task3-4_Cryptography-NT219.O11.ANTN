
#include <assert.h>

#include <iostream>
using std::cout;
using std::endl;

#include <string>
using std::string;

#include "cryptopp/osrng.h"
// using CryptoPP::AutoSeededX917RNG;
using CryptoPP::AutoSeededRandomPool;

#include "cryptopp/aes.h"
using CryptoPP::AES;

#include "cryptopp/integer.h"
using CryptoPP::Integer;

#include "cryptopp/sha.h"
using CryptoPP::SHA1;
#include "cryptopp/pem.h"
#include "cryptopp/pem_common.h"
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


#include "cryptopp/oids.h"
using CryptoPP::OID;

bool GeneratePrivateKey(const OID& oid, ECDSA<ECP, SHA1>::PrivateKey& key);
bool GeneratePublicKey(const ECDSA<ECP, SHA1>::PrivateKey& privateKey, ECDSA<ECP, SHA1>::PublicKey& publicKey);

void SavePrivateKey(const string& filename, const ECDSA<ECP, SHA1>::PrivateKey& key);
void SavePublicKey(const string& filename, const ECDSA<ECP, SHA1>::PublicKey& key);
extern "C" {
    __declspec(dllexport) bool key_gen(const char* filePub, const char* filePriv, int choice);
}

bool key_gen(const char* filePub, const char* filePriv, int choice)
{
     bool result = false;
     // Private and Public keys
     ECDSA<ECP, SHA1>::PrivateKey privateKey;
     ECDSA<ECP, SHA1>::PublicKey publicKey;

     /////////////////////////////////////////////
     // Generate Keys
     result = GeneratePrivateKey( CryptoPP::ASN1::secp160r1(), privateKey );
     assert( true == result);
     if (!result) { return 0; }

     result = GeneratePublicKey( privateKey, publicKey );
     assert( true == result );
     if( !result ) { return 0; }
     if (choice == 1)
     {
         SavePrivateKey(filePriv, privateKey);
         SavePublicKey(filePub, publicKey);
     }
     else if (choice == 2)
     {
         FileSink pub(filePub, true);
         PEM_Save(pub, publicKey);
         FileSink priv(filePriv, true);
         PEM_Save(priv, privateKey);
     }
     return 1;
}



bool GeneratePrivateKey(const OID& oid, ECDSA<ECP, SHA1>::PrivateKey& key)
{
    AutoSeededRandomPool prng;

    key.Initialize(prng, oid);
    assert(key.Validate(prng, 3));

    return key.Validate(prng, 3);
}

bool GeneratePublicKey(const ECDSA<ECP, SHA1>::PrivateKey& privateKey, ECDSA<ECP, SHA1>::PublicKey& publicKey)
{
    AutoSeededRandomPool prng;

    // Sanity check
    assert(privateKey.Validate(prng, 3));

    privateKey.MakePublicKey(publicKey);
    assert(publicKey.Validate(prng, 3));

    return publicKey.Validate(prng, 3);
}



void SavePrivateKey(const string& filename, const ECDSA<ECP, SHA1>::PrivateKey& key)
{
    key.Save(FileSink(filename.c_str(), true /*binary*/).Ref());
}

void SavePublicKey(const string& filename, const ECDSA<ECP, SHA1>::PublicKey& key)
{
    key.Save(FileSink(filename.c_str(), true /*binary*/).Ref());
}

