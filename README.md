# Tubes1_tembak2

## Deskripsi Singkat
Repository ini berisi implementasi bot untuk permainan Robocode Tank Royale menggunakan algoritma Greedy. Kami mengembangkan 4 bot berbeda, masing-masing menggunakan strategi Greedy dengan heuristik yang berbeda untuk memenangkan pertandingan.

## Algoritma Greedy yang Diimplementasikan

### SurvivorBot (Main Bot)
SurvivorBot mengimplementasikan **"Greedy by Survival"** yang fokus pada kelangsungan hidup sambil menyerang. Bot ini menggunakan:
- Pergerakan acak untuk menghindari tembakan lawan
- Penyesuaian kekuatan tembakan berdasarkan jarak dan energi
- Strategi khusus untuk menghindari tembok dan kontak dengan musuh
- Manajemen energi yang efisien

Bot ini menunjukkan performa terbaik di berbagai skenario pertempuran berkat keseimbangan antara serangan dan pertahanan.

### SmartGreedyBot (Alternative Bot 1)
Mengimplementasikan **"Greedy by Brutal Movement"** yang fokus pada pergerakan bot yang selalu dalam posisi menyerang serta mengambil langkah berdasarkan posisi musuh yang terdeteksi tanpa mempertimbangkan pergerakan musuh selanjutnya.

### BotMuter (Alternative Bot 2)
Mengimplementasikan **"Greedy by Maximum Firepower"** yang selalu menggunakan kekuatan tembakan maksimal tanpa mempertimbangkan efisiensi energi, bergerak dalam pola pentagon teratur.

### Berserker (Alternative Bot 3)
Mengimplementasikan **"Greedy by Aggression"** yang fokus pada damage output maksimal dan fast reaction movement, dengan pergerakan acak dan penembakan agresif.

## Requirement Program
- .NET SDK 6.0 atau lebih tinggi
- Robocode Tank Royale Game Engine (versi yang sudah dimodifikasi asisten)

## Cara Mengompilasi & Menjalankan Program

### Persiapan
1. Pastikan .NET SDK 6.0 atau lebih tinggi terinstal
2. Clone repository ini ke direktori lokal
3. Pastikan game engine Robocode Tank Royale sudah terinstal

### Kompilasi Bot
Untuk mengompilasi setiap bot, ikuti langkah-langkah berikut:

1. Buka terminal/command prompt
2. Pindah ke direktori bot yang ingin dikompilasi, misalnya:
```
cd src/main-bot/
```
3. Kompilasi menggunakan dotnet:
```
dotnet build
```

### Menjalankan Bot
1. Buka aplikasi Robocode Tank Royale GUI
2. Tambahkan direktori bot ke dalam "Bot Root Directories" (atau klik Ctrl + D)
3. Pilih folder bot yang ingin dijalankan dengan mengklik "Add" lalu pastikan tercentang 
4. Klik "Battle" dan "Start Battle" untuk membuat konfigurasi pertandingan (atau klik Ctrl + B)
5. Pilih Bot yang ingin dipertarungkan lalu klik "Boot"
6. Setelah Boot berhasil, Bot akan otomatis masuk ke Joined Bots, lalu "Add" atau "Add All" untuk menambah semua bot masuk ke battle participants
7. Lalu klik "Start Battle" untuk memulai pertandingan

### Apabila Tidak Bisa Diboot
Hapus folder "bin" yang terdapat pada folder bot yang tidak dapat di-boot, kemudian lakukan boot kembali

## Author
- 13523124 - Muhammad Raihaan Perdana
- 13523140 - Mahesa Fadhillah Andre
- 13523155 - M Abizzar Gamadrian

## Hasil Analisis
Berdasarkan hasil pengujian, SurvivorBot terbukti paling efektif dengan total skor 114 dari 25 pertandingan battle royale dan 25 pertandingan 1v1v1v1. SurvivorBot unggul karena memiliki strategi yang seimbang antara penyerangan dan pertahanan, dengan gerakan yang cepat dan sulit diprediksi serta efisiensi energi yang baik.
