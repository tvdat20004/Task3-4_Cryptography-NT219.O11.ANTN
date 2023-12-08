
#include "cryptopp/rsa.h"
using CryptoPP::RSA;
using CryptoPP::InvertibleRSAFunction;
using CryptoPP::RSAES_OAEP_SHA_Encryptor;
using CryptoPP::RSAES_OAEP_SHA_Decryptor;
#include "cryptopp/pem.h"
#include "cryptopp/pem_common.h"
#include "cryptopp/sha.h"
using CryptoPP::SHA1;
#include "cryptopp/base64.h"
using CryptoPP::Base64Encoder;
#include "cryptopp/filters.h"
using CryptoPP::StringSink;
using CryptoPP::StringSource;
using CryptoPP::PK_EncryptorFilter;
using CryptoPP::PK_DecryptorFilter;
#include <chrono>
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

// work with queue of byte
// #include "cryptopp/queue.h"
using CryptoPP::ByteQueue;
using CryptoPP::BufferedTransformation;
#include <string>
using std::string;

#include <exception>
using std::exception;

#include <iostream>
// #include <windows.h>
#include <fstream>

using std::cerr;
using std::cin;
using std::cout;
using std::endl;
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
            cout << line << endl;
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
    if (line.find("-----BEGIN RSA PRIVATE KEY-----") == std::string::npos)
    {
        return 0;
    }
    while (getline(file, line)) {
        if (line.find("-----END RSA PRIVATE KEY-----") != std::string::npos) {
            return 1;
        }
    }
    return 0;
}
int main(int argc, char* argv[])
{
    #ifdef __linux__
    std::locale::global(std::locale("C.UTF-8"));
    #endif
    #ifdef _WIN32
    // Set console code page to UTF-8 on Windows
    SetConsoleOutputCP(CP_UTF8);
    SetConsoleCP(CP_UTF8);
    #endif
    // define random generator
    
    AutoSeededRandomPool rng;
    if (argc == 1)
    {
        cerr << "Usage: task3 <mode>" << endl;
        cerr << "Mode: keygen, enc, dec" << endl;
        return 1;
    }
    int choose;
    if (string(argv[1]) == "keygen")
        choose = 1;
    else if (string(argv[1]) == "enc")
        choose = 2;
    else if (string(argv[1]) == "dec")
        choose = 3;
    else 
    {
        cerr << "Invalid mode:" << argv[1] << endl;
        return 1;
    }
    switch (choose)
    {
        case 1:
        {
            if (argc != 5)
            {
                cerr << "Usage: task3 keygen <Private key filename> <Public key file name> <file type>" << endl;
                cerr << "Supported file type: ber, pem." << endl;
                return 1;
            }
            string filePriv = string(argv[2]),filePub = string(argv[3]),fileType = string(argv[4]);
            // random RSA key
            
            // save RSA key to file
            if (fileType == "ber")
            {
                auto start = std::chrono::high_resolution_clock::now();
                //
                InvertibleRSAFunction parameters;
                parameters.GenerateRandomWithKeySize( rng, 3072 );
                RSA::PrivateKey priv( parameters );
                RSA::PublicKey pub( parameters );
                privKey = priv;
                pubKey = pub;
                EncodePrivateKey(filePriv.data(), priv);
                EncodePublicKey(filePub.data(), pub);
                //
                auto end = std::chrono::high_resolution_clock::now();
                auto duration = std::chrono::duration_cast<std::chrono::milliseconds>(end - start).count();
                cout << "Successfully save RSA keys.\n";
                cout << "Time for key generation: " << static_cast<double>(duration) << " microsecond"<<endl;   
                
            }
            else if (fileType == "pem")
            {
                auto start = std::chrono::high_resolution_clock::now();
                //
                InvertibleRSAFunction parameters;
                parameters.GenerateRandomWithKeySize( rng, 3072 );
                RSA::PrivateKey priv( parameters );
                RSA::PublicKey pub( parameters );
                privKey = priv;
                pubKey = pub;
                CryptoPP::FileSink public_key(filePub.data(), true);
                CryptoPP::PEM_Save(public_key, pub);
                CryptoPP::FileSink private_key(filePriv.data(), true);
                CryptoPP::PEM_Save(private_key, priv);
                //
                auto end = std::chrono::high_resolution_clock::now();
                auto duration = std::chrono::duration_cast<std::chrono::microseconds>(end - start).count();
                cout << "Successfully save RSA keys.\n";
                cout << "Time for key generation: " << static_cast<double>(duration) << " microsecond"<<endl;  
            }
            else 
            {
                cerr << "Invalid file type!!!" << endl;
                return 1;
            }
            break;
        }
        case 2:
        {
            // load RSA public key
            // cout << 11111111111111111111 << endl;
            if (argc != 5)
            {
                cerr << "Usage: task3 enc <Public_key_file> <file/screen> <plaintext>/<plaintextFilePath>"<<endl;
                cerr << "Example: task3 enc pub.pem file plain.txt"<<endl;
                return 1;
            }
            int enter;
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
                DecodePublicKey(filePubKey.data(), pubKey);
            else if (fileType == 1)
            {
                FileSource fs(filePubKey.data(), true);
                PEM_Load(fs, pubKey);
            }
            else 
            {
                cerr << "Fail to load RSA key!!!" << endl;
                return 1;
            }
            cout << "Successfully loaded RSA keys" << endl;
            string plain, cipher;
            switch (enter)
            {
                case 1:
                {
                    // enter plaintext from screen
                    plain = string(argv[4]);
                    break;
                }
                case 2:
                {
                    // enter plaintext from file
                    string filename = string(argv[4]);
                    FileSource(filename.data(), true, new StringSink(plain));
                    break;
                }
            }
            auto start = std::chrono::high_resolution_clock::now();
            //
            RSAES_OAEP_SHA_Encryptor e( pubKey );
            StringSource( plain, true,
                new PK_EncryptorFilter( rng, e,
                    new StringSink( cipher )
                ) // PK_EncryptorFilter
                ); // StringSource
            //
            auto end = std::chrono::high_resolution_clock::now();
            auto duration = std::chrono::duration_cast<std::chrono::microseconds>(end - start).count();
            cout << "Successfully encrypt RSA.\n";
            cout << "Time for encryption: " << static_cast<double>(duration) << " microsecond\n";
            //  Convert output into hexadecimal
            string encoded_hex;
            StringSource(cipher,true, new HexEncoder(new StringSink(encoded_hex)));
            
            switch (enter)
            {
                case 1:
                {
                    // display output on screen
                    cout << "Ciphertext (hex):" << encoded_hex << endl;
                    break;
                }
                case 2:
                {
                    StringSource(encoded_hex, true, new FileSink("cipher.txt"));
                    cout << "Successfully save ciphertext to cipher.txt" << endl;
                    break;
                }
                default:
                {
                    cout << "Invalid option\n";
                    return 0;
                }
            }
            break;
        }
        case 3:
        {
            if (argc != 5)
            {
                cerr << "Usage: task3 dec <Private_key_file> <file/screen> <ciphertext>/<ciphertext file path>"<<endl;
                cerr << "Example: task3 dec priv.pem file cipher.txt"<<endl;
                return 1;
            }
            int enter;
            string filePriv = string(argv[2]);
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
            int fileType = detect_pem_privkey(filePriv);
            // cout << fileType << endl;
            if (fileType == 0)
                DecodePrivateKey(filePriv.data(), privKey);
            else if (fileType == 1)
            {
                FileSource fs(filePriv.data(), true);
                PEM_Load(fs, privKey);
            }
            else 
            {
                cerr << "Fail to load RSA key!!!" << endl;
                return 1;
            }
            cout << "Successfully loaded RSA keys" << endl;
            string recovered, cipher;
            switch (enter)
            {
                case 1:
                {
                    // enter plaintext from screen
                    
                    string cipherHex = string(argv[4]);
                    StringSource(cipherHex, true, new HexDecoder(new StringSink(cipher)));
                    break;
                }
                case 2:
                {
                    // enter plaintext from file
                    string filename = string(argv[4]);
                    FileSource(filename.data(), true, new HexDecoder(new StringSink(cipher)));
                    break;
                }
            }
            auto start = std::chrono::high_resolution_clock::now();
            //
            // Decrypt RSA
            RSAES_OAEP_SHA_Decryptor d( privKey );
            StringSource( cipher, true,
                new PK_DecryptorFilter( rng, d,
                    new StringSink( recovered )
                )
                ); 
            //
            auto end = std::chrono::high_resolution_clock::now();
            auto duration = std::chrono::duration_cast<std::chrono::microseconds>(end - start).count();
            cout << "Successfully decrypt RSA.\n";
            cout << "Time for decryption: " << static_cast<double>(duration) << " microsecond\n";
            switch (enter)
            {
                case 1:
                {
                    // display output on screen
                    cout << "Recovered plaintext: " << recovered << endl;
                    break;
                }
                case 2:
                {
                    StringSource(recovered, true, new FileSink("recovered.txt"));
                    cout << "Successfully save plaintext to recovered.txt" << endl;
                    break;
                }
                default:
                {
                    cout << "Invalid option\n";
                    return 0;
                }
            }
            return 0;
        }
        default:
        {
            cerr << "Invalid option!!" << endl;
            return 0;
        }
    }
	return 0;
}
// 
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