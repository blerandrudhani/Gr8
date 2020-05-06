# Gr8


                                            Projekti në lëndën Siguria e të Dhënave
                                                      Faza e pare , Grupi8

Përdorimi : 


                                                   <args[0]>   <args[1]>      <args[2]>      <args[3]>
                                 Exit =>              1                   
                                Count =>           <teksti>       2           <opcioni>
                           Morse Code =>           <teksti>       3           <opcioni>
                  Caesar Cipher Code  =>           <teksti>       4           <opcioni>        <key>
           Caesar Cipher Brute Force  =>           <teksti>       4               3
                                  
                                  

Count  <opcioni>  =>    1 . Count Char , 2 . Count Lines , 3 . Count Word , 4 . Count Sentence , 5 . Count Wovels , 6 . Count Consonants, 7 . Count Symbols .  

Morse Code <opcioni> =>  1 . Encode , 2 . Decode .
           <teksti> =>  “.--. . .-. ... .... . -. -.. . - .--- .(+space)” .

Caesar Cipher Code <opcioni> =>  1 . Encode , 2 . Decode , 3 . Brute Force .




Përshkrimi : 

Komanda : 

Count Char – numëron karakteret
Count Lines – numëron rreshtat
Count Word – numëron fjalët
Count Sentence – numëron fjalitë
Count Wovels – numëron zanoret
Count consonants – numëron bashtingëlloret
Encode – kthen plaintext-in në ciphertext
Decode – kthen ciphertext-in në plaintext
Brute Force - provon të gjitha celësat e mundshëm dhe shfaq plaintext-in 



Rezultatet e ekzekutimit :

Komanda : 
                     Count :       
                           
C:\detyra>dS pershendetje 2 1
numri i charactereve : 12
C:\detyra>dS pershendetje 2 2
numri i rreshtave : 1
C:\detyra>dS pershendetje 2 3
numri i fjaleve : 1
C:\detyra>dS pershendetje 2 4
numri i fjalive : 0
C:\detyra>dS pershendetje 2 5
numri i zanoreve : 4
C:\detyra>dS pershendetje 2 6
numri i bashtingelloreve : 8
C:\detyra>dS pershendetje 2 7
numri i simboleve : 0


                 Morse Code :
              
C:\detyra>dS pershendetje 3 1
.--. . .-. ... .... . -. -.. . - .--- .
C:\detyra>dS ".--. . .-. ... .... . -. -.. . - .--- . " 3 2
Pershendetje


           Ceasar Cipher Code :

C:\detyra>dS pershendetje 4 3 1
ciphertext : shuvkhqghwmh
C:\detyra>dS shuvkhqghwmh 4 3 2
plaintext : pershendetje
           
           Brute force:
           
C:\detyra>prova shuvkhqghwmh 4 3
test 1: rgtujgpfgvlg
test 2: qfstifoefukf
test 3: pershendetje
test 4: odqrgdmcdsid
test 5: ncpqfclbcrhc
test 6: mbopebkabqgb
test 7: lanodajzapfa
test 8: kzmncziyzoez
test 9: jylmbyhxyndy
test 10: ixklaxgwxmcx
test 11: hwjkzwfvwlbw
test 12: gvijyveuvkav
test 13: fuhixudtujzu
test 14: etghwtcstiyt
test 15: dsfgvsbrshxs
test 16: crefuraqrgwr
test 17: bqdetqzpqfvq
test 18: apcdspyopeup
test 19: zobcroxnodto
test 20: ynabqnwmncsn
test 21: xmzapmvlmbrm
test 22: wlyzoluklaql
test 23: vkxynktjkzpk
test 24: ujwxmjsijyoj
test 25: tivwlirhixni
test 26: shuvkhqghwmh








                                         Projekti në lëndën Siguria e të Dhënave
                                                    Faza e dytë






Përdorimi : 


                                                  <args[0]>         <args[1]>        <args[2]>          <args[3]>

                     Create User   =>             create-user        <emri>      
                     Delete User   =>             delete-user        <emri>              
                     Import Key    =>             import-key         <emri>           <path>              
                   Export Key      =>             export-key         <emri>           <opcioni>  
                  Write Text       =>             write-text         <emri>           <mesazhi>           <path>      
                  Read Text        =>             read-text          <mesazhi>






Komanda : 


Create User – krijon celesin public dhe privat per perdoruesin

Delete User – fsjin celesin public dhe privat te perdoruesit

Import Key – e zhvendos celesin public apo privat prej nje lokacioni ne lokacionin tjeter

Export Key – e shfaq ne ekran celesin public apo privat varsisht nga opcioni I zgjedhur

Write text -  e enkodon nje tekst te dhene nga perdoruesi dhe e ruan ne nje file ne qofte se jepet path ose e shfaq ne ekran nese path                 nuk jepet

Read Text – e dekodon tekstin e dhene nga perdoruesi dhe e shfaq ne ekran tekstin e dekoduar

          








Rezultatet e ekzekutimit :


  
C:\detyra>b create-user siguria
 User :siguria u krijua
 



C:\detyra>b export-key siguria private
 Celesi privat ..: 
<RSAKeyValue><Modulus>tWDE0CgTAOQOWsGklkg+irGvDoLM/uGNCn3XeuTtqWLWrenZ15/VZ0/B/flYR4S0698sp18E+UoNOM1sE8V4bX1OnZrsp5O2rAOVYjMSoGrTn7B74kiInHeYQw/LZmZGghuxgqHvADoxyLj4jdGet2lM/+R2Aw5MopaHQ3BkqV0=</Modulus><Exponent>AQAB</Exponent><P>xlwndCJK8GPG30VWG712pKuHz/EXe/JJbItC7HMbNIHyRKqhMP3FRUoB/iM8Xg8ZY1wwjsNX2oMI7jyLA443lw==</P><Q>6hVWtwP3ArUQ9xxPmkwbiWQg4uimMAnQEiWPU7Gp09VFY8cJpV91k+WKefX3LZOgpRAFnZynYoH9Ow2PTVulKw==</Q><DP>v7aflznxrebxdieAcu0qNztl1w9QQEZKurLaKseReq1BZyZ3Bm+u8yn1RRfvJ4V2ZzbZ45FfXt0Yi5FOVlBk3w==</DP><DQ>56s4yCafZ8mFwdr+GWorcp1rQscX+sErcVpE8IML3f/cDfTl4gqI1le95hh9iljqC5LAzA1HR+H4mmJAKkKCQw==</DQ><InverseQ>BOFMMz/xEWfo7NzfAopBYRQypB68DYIbL53nxVUQ8LQCQVhG/tgs4R4mvDpyeBC0W9gFsd/kBuzpTBDaNEhe+A==</InverseQ><D>P0CzAkCnd+0QUHgtdLdXEDks6muVH+H6tMj0B4iklSjB4z6lWLwFyRSYe4CkV7Sg/40B3pCVhHZdrAx/f1mjSDzWdGsfjjt4LxFgdIBKUyu/z3fePtRVcCtrUv0niCjhFV6hyhjVCjdtdyPMgIfdfBx36AEJtGUciyHRbXDr+0U=</D></RSAKeyValue>




C:\detyra>b import-key siguri C:\Users\hp\Desktop\write.txt
 File u zhvendos : C:/Users/hp/Desktop/keys/siguri



C:\detyra>b write-text siguria pershendetje ""
SWfpsedDp/c=
Encrypted ...:        mQzcelucgVs= jKPLM9aNBXE= XulHvdCjBTHtInxydOjKXmIPG7l65ktphUB7B/6qqQ4Vx8G3XprR15WeXLxIiA6KTeSAD0LydLrGAkkePu/EqwpgtJpsOWdT/e3vQin65T6oNXPKzCzWKOuJTVkpj2kQe+GsbkiVCNp9h9M8xj3O6AQaFlnlNnxphlLrbVjX+9E= owd/gWUupcOFFOe9k5keJg==




C:\detyra>b read-text "mQzcelucgVs= jKPLM9aNBXE= XulHvdCjBTHtInxydOjKXmIPG7l65ktphUB7B/6qqQ4Vx8G3XprR15WeXLxIiA6KTeSAD0LydLrGAkkePu/EqwpgtJpsOWdT/e3vQin65T6oNXPKzCzWKOuJTVkpj2kQe+GsbkiVCNp9h9M8xj3O6AQaFlnlNnxphlLrbVjX+9E= owd/gWUupcOFFOe9k5keJg=="
 Emri ..:siguria
 Decrypted ..:pershendetje




C:\detyra>b delete-user siguria
 User : siguria u fshi
