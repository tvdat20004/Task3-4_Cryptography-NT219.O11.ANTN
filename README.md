# Task3-4_Cryptography-NT219.O11.ANTN
Task 3, 4: Use C# to build UI for task 3, 4

## Task 3: RSA Cipher (Encryption/Decryption) using CryptoPP
Required:\
+) Separation Encryption function and Decryption function (using switch case), Key generation
1) Key generation\
  Publickey, Privae  Key;\
  Save to file s (ber, pem);
2) Encryption\
+) Plaintext:
    - Support Vietnamese (UTF-8)
    - Input from screen or from file (using switch case and arguments in C++/C# in terminal or UI)
+) Secret key/public key
    - The keys load from files (for both two functions using arguments in C++/C# in terminal or UI)
    - The public key: >= 3072 bits
3) Decryption\
+) Ciphertext:
    - Input from screen or from file (using switch case and arguments in C++/C# in terminal or UI)\
+) Secret key/public key
    - The keys load from files (for both two functions and arguments in C++/C# in terminal or UI)
    - The public key: >= 3072 bits

+) OS platforms
  - Your code can compile on both Windows and Linux;\
+) Encryption Padding using OAEP;\
+) Performance
  - Report your hardware resources
  - Report computation performance for all operations on both Windows and Linux with different input size

## Task 4: ECC-based Digital signature with CryptoPP/Openssl
Required:
	
+) Separation the key generation, signing and the verify functions (using switch case)\
1) Key generation
  Publickey, Privae  Key;
  Save to file s (ber, pem);
2) signing function
    - May adopt library or direct compute from formulas. 
    - Deploy directly from formulas will get 15/100 bonus points. \
+) Message to sign
    - Input from file or screen
    - Support Vietnamese (using UTF-8)\
+) secret key
    - Input from file
3) Verify function
+) Message and signature
    - Input from files
    - Support Vietnamese (using UTF-8)\
+) public key key
   - Input from file

4) ECC curve:  should select from standard curves\
+) Secret key/public key
    - The keys load from files (for both two functions and arguments in C++/C# in terminal or UI)
    - The public key: >= 256 bits\
+) OS platforms
  - Your code can compile on both Windows and Linux;\
+) Performance
  - Report your hardware resources
  - Report computation performance for all operations on both Windows and Linux with different input size;
