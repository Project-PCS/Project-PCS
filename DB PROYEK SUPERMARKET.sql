---drop table
DROP TABLE BARANG CASCADE CONSTRAINT PURGE;
DROP TABLE PEGAWAI CASCADE CONSTRAINT PURGE;
DROP TABLE CUSTOMER CASCADE CONSTRAINT PURGE;
DROP TABLE KATEGORI CASCADE CONSTRAINT PURGE;
DROP TABLE SUPPLIER CASCADE CONSTRAINT PURGE;
DROP TABLE PROMO CASCADE CONSTRAINT PURGE;
DROP TABLE NOTAJUAL_HDR CASCADE CONSTRAINT PURGE;
DROP TABLE NOTAJUAL_BODY CASCADE CONSTRAINT PURGE;
DROP TABLE NOTASUPPLIER_HDR CASCADE CONSTRAINT PURGE;
DROP TABLE NOTASUPPLIER_BODY CASCADE CONSTRAINT PURGE;
DROP TABLE BARANG_MENARIK CASCADE CONSTRAINT PURGE;
DROP TABLE TUKARPOIN_HDR CASCADE CONSTRAINT PURGE;
DROP TABLE TUKARPOIN_BODY CASCADE CONSTRAINT PURGE;

--create table

CREATE TABLE CUSTOMER(
ID_CUSTOMER VARCHAR2(6) PRIMARY KEY,
NAMA_CUSTOMER VARCHAR2(20) NOT NULL,
JK VARCHAR2(1) NOT NULL,
ALAMAT_CUSTOMER VARCHAR2(50) NOT NULL,
NO_TELP VARCHAR2(13) NOT NULL,
POIN NUMBER(3) NOT NULL,
STATUS VARCHAR2(3) NOT NULL
);

CREATE TABLE PEGAWAI(
ID_PEGAWAI VARCHAR2(5) PRIMARY KEY,
NAMA_PEGAWAI VARCHAR2(20) NOT NULL,
JK VARCHAR2(1) NOT NULL,
NO_TELP VARCHAR2(13) NOT NULL,
ALAMAT VARCHAR2(50) NOT NULL,
SHIFT VARCHAR2 (20) NOT NULL,
STATUS NUMBER(1) NOT NULL
);

CREATE TABLE KATEGORI(
ID_KATEGORI VARCHAR2(10) PRIMARY KEY,
NAMA_KATEGORI VARCHAR2(20) NOT NULL,
STATUS VARCHAR2(3)
);

CREATE TABLE SUPPLIER(
ID_SUPPLIER VARCHAR2(10) PRIMARY KEY,
NAMA_SUPPLIER VARCHAR2(20) NOT NULL,
ALAMAT_SUPPLIER VARCHAR2(50) NOT NULL,
NOMOR_TELP VARCHAR2 (13) NOT NULL,
STATUS VARCHAR2(3)
);

CREATE TABLE BARANG(
ID_BARANG VARCHAR2(4) PRIMARY KEY,
NAMA_BARANG VARCHAR2(50) NOT NULL,
HARGA_ECERAN NUMBER(11) NOT NULL,
HARGA_GROSIR NUMBER(11) NOT NULL,
HARGA_BELI NUMBER(11) NOT NULL,
MIN_JUM_BARANG NUMBER (11) NOT NULL,
JUM_BARANG NUMBER(11) NOT NULL,
ID_SUPPLIER VARCHAR2(10) REFERENCES SUPPLIER(ID_SUPPLIER),
ID_KATEGORI VARCHAR2(10) REFERENCES KATEGORI(ID_KATEGORI) NOT NULL,
JUM_MIN_GROSIR NUMBER(11) NOT NULL,
STATUS VARCHAR2(3)
);

CREATE TABLE PROMO(
ID_PROMO VARCHAR2(5) PRIMARY KEY,
NAMA_PROMO VARCHAR2(20) NOT NULL,
ID_BARANG VARCHAR2(4) REFERENCES BARANG(ID_BARANG) NOT NULL,
POTONGAN_HARGA NUMBER(5) NOT NULL,
TANGGAL_PROMO DATE NOT NULL,
AKHIR_PROMO DATE NOT NULL
);

CREATE TABLE NOTAJUAL_HDR(
NO_NOTA VARCHAR2(7) PRIMARY KEY,
TANGGAL_NOTA DATE,
POIN NUMBER (2) NOT NULL,
ID_CUSTOMER VARCHAR(6) REFERENCES CUSTOMER(ID_CUSTOMER),
ID_PEGAWAI VARCHAR2(5) REFERENCES PEGAWAI(ID_PEGAWAI) NOT NULL
);

CREATE TABLE NOTAJUAL_BODY(
NO_NOTA REFERENCES NOTAJUAL_HDR(NO_NOTA),
ID_BARANG REFERENCES BARANG(ID_BARANG),
QTY NUMBER(3) NOT NULL,
HARGA_JUAL NUMBER(8) NOT NULL
);

CREATE TABLE NOTASUPPLIER_HDR(
NO_NOTA VARCHAR2(7) PRIMARY KEY,
ID_SUPPLIER VARCHAR(10) REFERENCES SUPPLIER(ID_SUPPLIER),
TANGGAL_PEMBAYARAN DATE,
BATAS_PEMBAYARAN DATE NOT NULL,
STATUS NUMBER(1) NOT NULL
);

CREATE TABLE NOTASUPPLIER_BODY(
NO_NOTA REFERENCES NOTASUPPLIER_HDR(NO_NOTA),
ID_BARANG REFERENCES BARANG(ID_BARANG),
QTY NUMBER(3) NOT NULL,
HARGA_BELI NUMBER(8) NOT NULL
);

CREATE TABLE BARANG_MENARIK(
ID_BARANG_MENARIK VARCHAR2(10) PRIMARY KEY,
ID_BARANG REFERENCES BARANG(ID_BARANG),
JML_BARANG NUMBER(3),
JML_POIN NUMBER(3),
STATUS_BERLAKU NUMBER(1)
);

CREATE TABLE TUKARPOIN_HDR(
ID_TUKAR_POIN VARCHAR2(10) PRIMARY KEY,
ID_CUSTOMER REFERENCES CUSTOMER(ID_CUSTOMER),
TGL_TUKAR_POIN DATE NOT NULL
);

CREATE TABLE TUKARPOIN_BODY(
ID_TUKAR_POIN REFERENCES TUKARPOIN_HDR(ID_TUKAR_POIN),
ID_BARANG_MENARIK REFERENCES BARANG_MENARIK(ID_BARANG_MENARIK)
);

--insert into

INSERT INTO CUSTOMER VALUES('CUS001','Alexander Widodo','L','Jl. Dharmausada Indah Timur IV/105','081333168889',20,'1');
INSERT INTO CUSTOMER VALUES('CUS002','Fitri Nabilla','P','Jl. Ngagel Jaya Selatan 156','08112312367',10,'1');
INSERT INTO CUSTOMER VALUES('CUS003','Billy Saputra','L','Galaxy Bumi Permai I Blok B-5','082364363689',5,'1');
INSERT INTO CUSTOMER VALUES('CUS004','Carolina Kosasih','P','Regency 21 blok H-50','03171525088',12,'1');
INSERT INTO CUSTOMER VALUES('CUS005','Jesselyn Wijaya','P','Puri Galaxy Bamboo Lakes Blok C-7','081706900878',7,'1');
INSERT INTO CUSTOMER VALUES('CUS006','Andreas Gunawan','L','Jl. Klampis Anom No.48','04159978947',35,'1');
INSERT INTO CUSTOMER VALUES('CUS007','Vicky Yuwono','L','Jl. Kertajaya No.222','0853218889',8,'1');
INSERT INTO CUSTOMER VALUES('CUS008','Michelle Hadi','P','Dharmausada Indah Utara V/65','085123789372',90,'1');
INSERT INTO CUSTOMER VALUES('CUS009','Olivia Cahya','P','Jl. Arief Rahman Hakim no 145-146','03178936829',105,'1');
INSERT INTO CUSTOMER VALUES('CUS010','Cynthia Dewi','P','Jl. Raya Laguna KJW Putih Tambak No.32','081666677779',220,'1');
INSERT INTO CUSTOMER VALUES('CUS011','Jason Paulino','L','Jl. Embong Sawo No.22','062887862829',200,'1');
INSERT INTO CUSTOMER VALUES('CUS012','Felicia Yuana','P','Jl. Walikota Mustajab No.50','085777783930',92,'1');
INSERT INTO CUSTOMER VALUES('CUS013','Gabriella Tanoyo','P','Jl. Mleto No.42 A','081537392829',43,'1');
INSERT INTO CUSTOMER VALUES('CUS014','Liliana Betty','P',' Jl. Kapasari No.97-101','08263738678',80,'1');
INSERT INTO CUSTOMER VALUES('CUS015','Mega Tan','P','Jl. Tumapel No.78','082738392728',20,'1');

INSERT INTO PEGAWAI VALUES('PEG01','Ani','W','08170388889','Jl mawar no 2','Pagi',1);
INSERT INTO PEGAWAI VALUES('PEG02','Fiko','P','081200385889','Jl duren no 11','Pagi',1);
INSERT INTO PEGAWAI VALUES('PEG03','Jaya', 'P','08537897289','Kertajaya Indah no 11','Malam',1);
INSERT INTO PEGAWAI VALUES('PEG04','Nicholas','P','08573454289','Jl Ngagel Jaya Tengah no 8','Siang',0);
INSERT INTO PEGAWAI VALUES('PEG05','Wilson','P','085783937207','Jl Anugrah no 20','Malam',0);
INSERT INTO PEGAWAI VALUES('PEG06','Hana','W','08150380890','Jl juanda no 12','Pagi',1);
INSERT INTO PEGAWAI VALUES('PEG07','Juliana','W','081693321889','Jl cempaka no 32','Siang',1);
INSERT INTO PEGAWAI VALUES('PEG08','Iona','W','08123468889','Jl cendra no 2','Siang',1);

--GROCERY: MIE INSTAN, SIRUP, SAOS, KOPI, SUSU
INSERT INTO KATEGORI VALUES('KAT01','Makanan ringan','1');
INSERT INTO KATEGORI VALUES('KAT02','Minuman dan Rokok','1');
INSERT INTO KATEGORI VALUES('KAT03','Bahan Pokok','1'); 
INSERT INTO KATEGORI VALUES('KAT04','Grocery','1');
INSERT INTO KATEGORI VALUES('KAT05','Household','1');
INSERT INTO KATEGORI VALUES('KAT06','Perawatan Tubuh','1');
INSERT INTO KATEGORI VALUES('KAT07','Dairy','1');

INSERT INTO SUPPLIER VALUES('SUP001','SuryaCitra Adikusuma','Jl. Raya Gubeng No.19-21','0315998984','1');
INSERT INTO SUPPLIER VALUES('SUP002','Sinar Inti','Ruko Rungkut Megah Raya, Jl. Raya Rungkut No.5','0315987774','1');
INSERT INTO SUPPLIER VALUES('SUP003','Indofood','Jl. Tenggilis Lama III B No.45','03171525088','1');
INSERT INTO SUPPLIER VALUES('SUP004','SH Grosir','Jl. Rungkut Industri III No.17','0817047547','1');
INSERT INTO SUPPLIER VALUES('SUP005','Kemang Food','Jl. Ketintang Baru No.30-32','0315949399','1');
INSERT INTO SUPPLIER VALUES('SUP006','Indotrada Utama','Jl. Jeruk no. 99','0315947533','1');
INSERT INTO SUPPLIER VALUES('SUP007','Ajinomoto','Jl. Jend Gatot Subroto Bl 7/1-A ','0247618871','1');
INSERT INTO SUPPLIER VALUES('SUP008','Bogasari','Jl. Nilam Barat No.16','0313293081','1');
INSERT INTO SUPPLIER VALUES('SUP009','Nutrifood','Jl. Jendral Sudirman No.144','0315915567','1');
INSERT INTO SUPPLIER VALUES('SUP010','Coca Cola','Jl. Hanoman Raya No.6','03150146','1');
INSERT INTO SUPPLIER VALUES('SUP011','KAO Indonesia','Jl.Kalirungkut No. 19-21','03150213636','1');
INSERT INTO SUPPLIER VALUES('SUP012','Unilever Indonesia','Jl. Rungkut Industri IV No.5-11','0318438297','1');
INSERT INTO SUPPLIER VALUES('SUP013','Gading Puri Perkasa','Jl. Kenjeran No.61760114','0313812832','1');

INSERT INTO BARANG VALUES('B001','Indomie kuah',2500,2300,1500,150,180,'SUP003','KAT04',40,'1');
INSERT INTO BARANG VALUES('B002','Indomie goreng',3000,2800,2000,200,150,'SUP003','KAT04',40,'1');
INSERT INTO BARANG VALUES('B003','Sirup Marjan',25000,22000,19000,100,155,'SUP003','KAT04',12,'1');
INSERT INTO BARANG VALUES('B004','Biskuat Original',7000,6800,5000,50,75,'SUP006','KAT01',20,'1');
INSERT INTO BARANG VALUES('B005','Biskuat Coklat',7000,6800,5000,45,55,'SUP006','KAT01',20,'1');
INSERT INTO BARANG VALUES('B006','Potato Chips',9000,8800,8000,80,90,'SUP005','KAT01',40,'1');
INSERT INTO BARANG VALUES('B007','Masako',1500,1300,500,100,150,'SUP007','KAT04',50,'1');
INSERT INTO BARANG VALUES('B008','Garam Dapur',5000,4500,4000,150,200,'SUP001','KAT03',40,'1');
INSERT INTO BARANG VALUES('B009','Gula',8000,7800,7000,150,200,'SUP001','KAT03',40,'1');
INSERT INTO BARANG VALUES('B010','Bango Kecap manis',23000,22800,20000,100,150,'SUP002','KAT04',20,'1');
INSERT INTO BARANG VALUES('B011','Kecap asin',21500,21000,20000,80,100,'SUP002','KAT04',20,'1');
INSERT INTO BARANG VALUES('B012','Bimoli Minyak Goreng 2 Liter',25000,24700,23500,100,120,'SUP004','KAT03',12,'1');
INSERT INTO BARANG VALUES('B013','Tepung Beras Putih',7000,6800,5500,80,100,'SUP008','KAT03',40,'1');
INSERT INTO BARANG VALUES('B014','Tepung Segitiga Biru',10500,10000,8000,80,100,'SUP008','KAT03',40,'1');
INSERT INTO BARANG VALUES('B015','Nutrijell Jelly Powder',5100,5000,4000,50,70,'SUP009','KAT04',20,'1');
INSERT INTO BARANG VALUES('B016','Yoghurt',12000,11500,10000,100,50,'SUP009','KAT07',50,'1');
INSERT INTO BARANG VALUES('B017','Fanta 390 ml',5000,4500,4000,100,120,'SUP010','KAT02',40,'1');
INSERT INTO BARANG VALUES('B018','Coca Cola 390 ml',5000,4500,4000,120,130,'SUP010','KAT02',24,'1');
INSERT INTO BARANG VALUES('B019','Coca Cola 1.5 L',15000,14500,12000,80,100,'SUP010','KAT02',12,'1');
INSERT INTO BARANG VALUES('B020','Aqua Botol 600 ml',2500,2300,2000,300,450,'SUP005','KAT02',24,'1');
INSERT INTO BARANG VALUES('B021','Aqua Galon 19 L',50000,49000,45000,80,90,'SUP005','KAT02',12,'1');
INSERT INTO BARANG VALUES('B022','Tissue Gulung',4000,3800,3000,150,200,'SUP006','KAT05',40,'1');
INSERT INTO BARANG VALUES('B023','Pembalut',25000,23000,20000,100,150,'SUP006','KAT06',12,'1');
INSERT INTO BARANG VALUES('B024','Sunlight Cairan Pencuci Piring',14000,13750,11000,80,100,'SUP013','KAT05',30,'1');
INSERT INTO BARANG VALUES('B025','Dettol Sabun Mandi Batang',5000,4700,4000,80,100,'SUP013','KAT06',20,'1');
INSERT INTO BARANG VALUES('B026','Biore Facial Foam',23000,22500,21000,60,80,'SUP011','KAT06',20,'1');
INSERT INTO BARANG VALUES('B027','Biore Pore Pack',11000,10800,10000,40,45,'SUP011','KAT06',12,'1');
INSERT INTO BARANG VALUES('B028','Lifebuoy Shampoo',17000,16500,15000,100,150,'SUP012','KAT06',30,'1');
INSERT INTO BARANG VALUES('B029','Baygon',54500,53000,50000,80,100,'SUP012','KAT05',20,'1');
INSERT INTO BARANG VALUES('B030','Marlboro Merah',23000,22500,20000,100,120,'SUP012','KAT02',12,'1');
INSERT INTO BARANG VALUES('B031','Mie Sedap Goreng',2000,1500,1000,150,160,'SUP005','KAT04',12,'1');
INSERT INTO BARANG VALUES('B032','Mie Sedap Kuah',2000,1500,1000,150,200,'SUP005','KAT04',12,'1');
INSERT INTO BARANG VALUES('B033','Telur Ayam Kampung',25000,24500,22000,50,60,'SUP002','KAT03',40,'1');
INSERT INTO BARANG VALUES('B034','Keju Kraft Singles',14000,13500,11000,70,75,'SUP002','KAT07',40,'1');
INSERT INTO BARANG VALUES('B035','Ultra Milk Full Cream 1L',17500,17000,15000,150,200,'SUP002','KAT07',40,'1');
INSERT INTO BARANG VALUES('B036','Bear Brand Susu Kaleng',7500,7000,5000,80,100,'SUP002','KAT07',40,'1');
INSERT INTO BARANG VALUES('B037','Beras Raja Lele 3 KG',35000,34000,30000,20,30,'SUP002','KAT03',12,'1');
INSERT INTO BARANG VALUES('B038','Beras Raja Lele 5 KG',50000,48000,45000,10,15,'SUP002','KAT03',12,'1');
INSERT INTO BARANG VALUES('B039','Teh Pucuk Harum',4500,4300,3500,100,150,'SUP005','KAT07',40,'1');
INSERT INTO BARANG VALUES('B040','Sajiku Tepung Bumbu',5500,5200,4500,80,100,'SUP002','KAT04',40,'1');
INSERT INTO BARANG VALUES('B041','Ajinomoto',5500,5000,4000,50,100,'SUP002','KAT04',20,'1');

INSERT INTO PROMO VALUES('DIS01','DISKON','B022',15,TO_DATE('2019-05-01','YYYY-MM-DD'), TO_DATE('2019-05-07','YYYY-MM-DD'));
INSERT INTO PROMO VALUES('DIS02','DISKON','B035',10,TO_DATE('2019-05-08','YYYY-MM-DD'), TO_DATE('2019-05-14','YYYY-MM-DD'));
INSERT INTO PROMO VALUES('DIS03','POTONGAN','B005',1000,TO_DATE('2019-05-15','YYYY-MM-DD'), TO_DATE('2019-05-21','YYYY-MM-DD'));
INSERT INTO PROMO VALUES('DIS04','POTONGAN','B012',3000,TO_DATE('2019-05-22','YYYY-MM-DD'), TO_DATE('2019-05-26','YYYY-MM-DD'));
INSERT INTO PROMO VALUES('DIS05','DISKON','B024',10,TO_DATE('2019-05-27','YYYY-MM-DD'), TO_DATE('2019-05-31','YYYY-MM-DD'));

INSERT INTO NOTAJUAL_HDR VALUES('JUAL001',TO_DATE('2019-05-05','YYYY-MM-DD'),8,'CUS001','PEG01');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL002',TO_DATE('2019-05-05','YYYY-MM-DD'),0,'CUS002','PEG02');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL003',TO_DATE('2019-05-05','YYYY-MM-DD'),2,'CUS003','PEG02');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL004',TO_DATE('2019-05-05','YYYY-MM-DD'),1,'CUS004','PEG03');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL005',TO_DATE('2019-05-04','YYYY-MM-DD'),5,'CUS005','PEG03');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL006',TO_DATE('2019-05-04','YYYY-MM-DD'),5,'CUS006','PEG03');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL007',TO_DATE('2019-05-04','YYYY-MM-DD'),3,'CUS007','PEG04');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL008',TO_DATE('2019-05-03','YYYY-MM-DD'),3,'CUS008','PEG07');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL009',TO_DATE('2019-05-03','YYYY-MM-DD'),2,'CUS009','PEG07');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL010',TO_DATE('2019-05-02','YYYY-MM-DD'),2,'CUS010','PEG04');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL011',TO_DATE('2019-05-01','YYYY-MM-DD'),2,'CUS011','PEG04');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL012',TO_DATE('2019-04-30','YYYY-MM-DD'),12,'CUS012','PEG05');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL013',TO_DATE('2019-04-29','YYYY-MM-DD'),3,'CUS013','PEG05');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL014',TO_DATE('2019-04-28','YYYY-MM-DD'),4,'CUS014','PEG08');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL015',TO_DATE('2019-04-27','YYYY-MM-DD'),6,'CUS015','PEG08');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL016',TO_DATE('2019-04-26','YYYY-MM-DD'),0,'CUS006','PEG05');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL017',TO_DATE('2019-04-25','YYYY-MM-DD'),1,'CUS007','PEG04');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL018',TO_DATE('2019-04-24','YYYY-MM-DD'),2,'CUS008','PEG03');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL019',TO_DATE('2019-04-23','YYYY-MM-DD'),1,'CUS009','PEG01');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL020',TO_DATE('2019-04-22','YYYY-MM-DD'),1,'CUS010','PEG02');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL021',TO_DATE('2019-04-21','YYYY-MM-DD'),5,NULL,'PEG03');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL022',TO_DATE('2019-04-20','YYYY-MM-DD'),5,'CUS001','PEG04');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL023',TO_DATE('2019-04-19','YYYY-MM-DD'),14,'CUS003','PEG05');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL024',TO_DATE('2019-04-18','YYYY-MM-DD'),1,'CUS004','PEG06');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL025',TO_DATE('2019-04-17','YYYY-MM-DD'),3,'CUS009','PEG07');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL026',TO_DATE('2019-04-16','YYYY-MM-DD'),2,'CUS012','PEG08');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL027',TO_DATE('2019-04-15','YYYY-MM-DD'),7,'CUS015','PEG01');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL028',TO_DATE('2019-04-14','YYYY-MM-DD'),2,'CUS004','PEG02');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL029',TO_DATE('2019-04-13','YYYY-MM-DD'),3,NULL,'PEG03');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL030',TO_DATE('2019-04-12','YYYY-MM-DD'),2,NULL,'PEG04');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL031',TO_DATE('2019-04-11','YYYY-MM-DD'),2,NULL,'PEG05');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL032',TO_DATE('2019-04-10','YYYY-MM-DD'),9,'CUS002','PEG06');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL033',TO_DATE('2019-04-09','YYYY-MM-DD'),0,'CUS015','PEG07');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL034',TO_DATE('2019-04-08','YYYY-MM-DD'),4,'CUS011','PEG08');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL035',TO_DATE('2019-04-07','YYYY-MM-DD'),7,'CUS008','PEG01');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL036',TO_DATE('2019-04-06','YYYY-MM-DD'),0,'CUS007','PEG02');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL037',TO_DATE('2019-04-05','YYYY-MM-DD'),1,'CUS004','PEG03');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL038',TO_DATE('2019-04-04','YYYY-MM-DD'),1,'CUS002','PEG04');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL039',TO_DATE('2019-04-03','YYYY-MM-DD'),5,NULL,'PEG05');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL040',TO_DATE('2019-04-02','YYYY-MM-DD'),1,NULL,'PEG06');
INSERT INTO NOTAJUAL_HDR VALUES('JUAL041',TO_DATE('2019-04-01','YYYY-MM-DD'),1,NULL,'PEG07');

INSERT INTO NOTAJUAL_BODY VALUES('JUAL001','B033',2,25000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL001','B035',1,17500);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL001','B024',1,14000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL002','B020',3,2500);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL003','B001',2,2500);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL003','B002',5,3000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL003','B022',1,4000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL004','B024',1,14000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL005','B025',1,5000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL005','B012',2,25000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL006','B033',2,25000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL007','B004',2,7000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL007','B032',2,8000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL008','B009',4,8000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL009','B014',2,10500);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL010','B015',4,5100);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL011','B017',5,5000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL012','B015',4,5100);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL012','B034',1,14000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL012','B010',1,23000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL012','B015',4,5100);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL012','B021',1,50000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL013','B016',1,12000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL013','B026',1,23000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL013','B031',15,8500);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL014','B035',2,17500);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL014','B013',1,7000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL014','B032',18,8000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL015','B003',1,25000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL015','B015',4,5100);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL015','B030',1,23000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL015','B031',10,8500);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL016','B007',4,1500);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL016','B032',15,8000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL017','B025',2,5000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL017','B018',1,5000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL018','B012',1,25000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL019','B017',2,5000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL020','B020',4,2500);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL021','B005',2,7000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL021','B006',1,9000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL021','B009',4,8000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL022','B023',2,25000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL023','B039',5,4500);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL023','B025',30,4700);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL024','B022',3,4000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL025','B025',1,5000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL025','B014',3,10500);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL026','B024',2,14000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL027','B040',5,5500);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL027','B038',1,50000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL028','B036',4,7500);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL029','B028',2,17000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL030','B015',4,5100);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL031','B017',5,5000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL032','B010',2,23000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL032','B016',2,12000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL032','B010',1,23000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL033','B013',1,7000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL034','B030',2,23000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL035','B037',1,35000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL035','B015',4,5100);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL035','B030',1,23000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL036','B006',1,9000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL037','B027',1,11000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL038','B025',2,5000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL039','B033',2,25000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL040','B017',2,5000);
INSERT INTO NOTAJUAL_BODY VALUES('JUAL041','B020',4,2500);

INSERT INTO NOTASUPPLIER_HDR VALUES('JSUP001','SUP001',NULL,TO_DATE('2019-05-15','YYYY-MM-DD'),0);
INSERT INTO NOTASUPPLIER_HDR VALUES('JSUP002','SUP001',NULL,TO_DATE('2019-05-15','YYYY-MM-DD'),0);
INSERT INTO NOTASUPPLIER_HDR VALUES('JSUP003','SUP002',TO_DATE('2019-04-29','YYYY-MM-DD'),TO_DATE('2019-05-1','YYYY-MM-DD'),1);
INSERT INTO NOTASUPPLIER_HDR VALUES('JSUP004','SUP003',NULL,TO_DATE('2019-05-10','YYYY-MM-DD'),0);
INSERT INTO NOTASUPPLIER_HDR VALUES('JSUP005','SUP004',TO_DATE('2019-04-26','YYYY-MM-DD'),TO_DATE('2019-04-30','YYYY-MM-DD'),1);
INSERT INTO NOTASUPPLIER_HDR VALUES('JSUP006','SUP005',TO_DATE('2019-04-24','YYYY-MM-DD'),TO_DATE('2019-04-25','YYYY-MM-DD'),1);
INSERT INTO NOTASUPPLIER_HDR VALUES('JSUP007','SUP006',NULL,TO_DATE('2019-05-10','YYYY-MM-DD'),0);
INSERT INTO NOTASUPPLIER_HDR VALUES('JSUP008','SUP007',NULL,TO_DATE('2019-05-10','YYYY-MM-DD'),0);
INSERT INTO NOTASUPPLIER_HDR VALUES('JSUP009','SUP008',TO_DATE('2019-04-26','YYYY-MM-DD'),TO_DATE('2019-04-30','YYYY-MM-DD'),1);
INSERT INTO NOTASUPPLIER_HDR VALUES('JSUP010','SUP009',TO_DATE('2019-04-25','YYYY-MM-DD'),TO_DATE('2019-04-28','YYYY-MM-DD'),1);
INSERT INTO NOTASUPPLIER_HDR VALUES('JSUP011','SUP010',NULL,TO_DATE('2019-05-15','YYYY-MM-DD'),0);
INSERT INTO NOTASUPPLIER_HDR VALUES('JSUP012','SUP011',TO_DATE('2019-04-26','YYYY-MM-DD'),TO_DATE('2019-04-30','YYYY-MM-DD'),1);
INSERT INTO NOTASUPPLIER_HDR VALUES('JSUP013','SUP011',NULL,TO_DATE('2019-05-15','YYYY-MM-DD'),0);


INSERT INTO NOTASUPPLIER_BODY VALUES('JSUP001','B008',200,4000);
INSERT INTO NOTASUPPLIER_BODY VALUES('JSUP002','B009',200,7000);
INSERT INTO NOTASUPPLIER_BODY VALUES('JSUP003','B011',100,20000);
INSERT INTO NOTASUPPLIER_BODY VALUES('JSUP004','B002',400,2000);
INSERT INTO NOTASUPPLIER_BODY VALUES('JSUP005','B012',200,23500);
INSERT INTO NOTASUPPLIER_BODY VALUES('JSUP006','B006',100,8000);
INSERT INTO NOTASUPPLIER_BODY VALUES('JSUP007','B022',200,3000);
INSERT INTO NOTASUPPLIER_BODY VALUES('JSUP008','B007',150,500);
INSERT INTO NOTASUPPLIER_BODY VALUES('JSUP009','B013',150,5500);
INSERT INTO NOTASUPPLIER_BODY VALUES('JSUP010','B018',150,4000);
INSERT INTO NOTASUPPLIER_BODY VALUES('JSUP011','B015',80,4000);
INSERT INTO NOTASUPPLIER_BODY VALUES('JSUP012','B026',100,21000);
INSERT INTO NOTASUPPLIER_BODY VALUES('JSUP013','B027',60,10000);

INSERT INTO BARANG_MENARIK VALUES('BM001','B009',1,9,1);
INSERT INTO BARANG_MENARIK VALUES('BM002','B007',3,7,1);
INSERT INTO BARANG_MENARIK VALUES('BM003','B010',1,23,1);
INSERT INTO BARANG_MENARIK VALUES('BM004','B012',1,25,1);
INSERT INTO BARANG_MENARIK VALUES('BM005','B017',1,6,1);
INSERT INTO BARANG_MENARIK VALUES('BM006','B002',3,8,1);
INSERT INTO BARANG_MENARIK VALUES('BM007','B028',1,17,1);
INSERT INTO BARANG_MENARIK VALUES('BM008','B039',2,10,1);
INSERT INTO BARANG_MENARIK VALUES('BM009','B025',2,10,1);
INSERT INTO BARANG_MENARIK VALUES('BM010','B024',1,14,1);

INSERT INTO TUKARPOIN_HDR VALUES('TP001','CUS001',to_date('2019-04-13','YYYY-MM-DD'));
INSERT INTO TUKARPOIN_HDR VALUES('TP002','CUS011',to_date('2019-04-15','YYYY-MM-DD'));
INSERT INTO TUKARPOIN_HDR VALUES('TP003','CUS008',to_date('2019-04-15','YYYY-MM-DD'));
INSERT INTO TUKARPOIN_HDR VALUES('TP004','CUS004',to_date('2019-04-19','YYYY-MM-DD'));
INSERT INTO TUKARPOIN_HDR VALUES('TP005','CUS009',to_date('2019-04-24','YYYY-MM-DD'));
INSERT INTO TUKARPOIN_HDR VALUES('TP006','CUS008',to_date('2019-05-03','YYYY-MM-DD'));
INSERT INTO TUKARPOIN_HDR VALUES('TP007','CUS013',to_date('2019-05-10','YYYY-MM-DD'));
INSERT INTO TUKARPOIN_HDR VALUES('TP008','CUS015',to_date('2019-05-10','YYYY-MM-DD'));
INSERT INTO TUKARPOIN_HDR VALUES('TP009','CUS012',to_date('2019-05-17','YYYY-MM-DD'));
INSERT INTO TUKARPOIN_HDR VALUES('TP010','CUS006',to_date('2019-05-19','YYYY-MM-DD'));

INSERT INTO TUKARPOIN_BODY VALUES('TP001','BM005');
INSERT INTO TUKARPOIN_BODY VALUES('TP002','BM004');
INSERT INTO TUKARPOIN_BODY VALUES('TP002','BM010');
INSERT INTO TUKARPOIN_BODY VALUES('TP003','BM003');
INSERT INTO TUKARPOIN_BODY VALUES('TP003','BM004');
INSERT INTO TUKARPOIN_BODY VALUES('TP004','BM005');
INSERT INTO TUKARPOIN_BODY VALUES('TP005','BM007');
INSERT INTO TUKARPOIN_BODY VALUES('TP005','BM004');
INSERT INTO TUKARPOIN_BODY VALUES('TP006','BM007');
INSERT INTO TUKARPOIN_BODY VALUES('TP007','BM001');
INSERT INTO TUKARPOIN_BODY VALUES('TP007','BM008');
INSERT INTO TUKARPOIN_BODY VALUES('TP007','BM009');
INSERT INTO TUKARPOIN_BODY VALUES('TP008','BM006');
INSERT INTO TUKARPOIN_BODY VALUES('TP009','BM002');
INSERT INTO TUKARPOIN_BODY VALUES('TP009','BM009');
INSERT INTO TUKARPOIN_BODY VALUES('TP010','BM002');
INSERT INTO TUKARPOIN_BODY VALUES('TP010','BM005');

--FUNCTION

--AUTOGEN ID PROMO
create or replace function autogenPromo
return varchar2
is
id varchar2(10);
begin
	select 'DIS'||LPAD(NVL(MAX(SUBSTR(id_promo, -2, 2)) + 1,1),2,'0') into id from PROMO;
	return id;
end;
/
--AUTOGEN CUSTOMER
create or replace function autogenCustomer
return varchar2
is
id varchar2(10);
begin
	select 'CUS'||LPAD(NVL(MAX(SUBSTR(id_customer, -2, 2)) + 1,1),3,'0') into id from customer;
	return id;
end;
/
--AUTOGEN PEGAWAI
create or replace function autogenPegawai
return varchar2
is
id varchar2(10);
begin
	select 'PEG'||LPAD(NVL(MAX(SUBSTR(id_pegawai, -2, 2)) + 1,1),2,'0') into id from pegawai;
	return id;
end;
/

--AUTOGEN NO_NOTA JUAL
create or replace function NewNotaJual
return varchar2
is
	ctr varchar2(3);
	idnota varchar2(7);
begin
	select lpad(count(*)+1, 3, 0) into ctr
	from notajual_hdr;
	
	idnota := 'JUAL' || ctr;
	return idnota;
end;
/

--AUTOGEN ID BARANG MENARIK
create or replace function NewBarangMenarik
return varchar2
is
	ctr varchar2(3);
	idbaru varchar2(7);
begin
	select lpad(count(*)+1, 3, 0) into ctr
	from barang_menarik;
	
	idbaru := 'BM' || ctr;
	return idbaru;
end;
/

--PROCEDURE 
--CEK NAMA BARANG
create or replace procedure cekNamaBarang(nama_barang_param in varchar2)
is
    error_namabarang exception;
begin
 for i in(
        select * from barang where nama_barang=nama_barang_param
    )loop
        raise error_namabarang;
    end loop;
 exception 
  when error_namabarang then
   raise_application_error(-20001,'Nama Barang Sama');
end;
/

--CEK PROMO
create or replace procedure cekPromo(pid_barang in varchar2, pawal in varchar2, pakhir in varchar2)
is
    error_exist exception;
begin
 for i in(
        select * from promo where id_barang=pid_barang and tanggal_promo = pawal and akhir_promo = pakhir
    )loop
        raise error_exist;
    end loop;
 exception 
  when error_exist then
   raise_application_error(-20001,'Promo sudah terdaftar');
end;
/
--CEK NO TELP CUST
create or replace procedure cekNotelpCust(pno_telp in varchar2)
is
    error_exist exception;
begin
 for i in(
        select * from customer where no_telp=pno_telp
    )loop
        raise error_exist;
    end loop;
 exception 
  when error_exist then
   raise_application_error(-20001,'No telp sudah terdaftar');
end;
/

--CEK NO TELP PEGAWAI
create or replace procedure cekNotelpPeg(pno_telp in varchar2)
is
    error_exist exception;
begin
 for i in(
        select * from pegawai where no_telp=pno_telp
    )loop
        raise error_exist;
    end loop;
 exception 
  when error_exist then
   raise_application_error(-20001,'No telp sudah terdaftar');
end;
/
--TRIGGER
--1
create or replace trigger insertbarang
before insert or update
on barang
for each row
declare
id varchar2(5);
error_harga exception;
error_grosir exception;
begin
 
 if inserting then
  select 'B'||lpad(max(substr(id_barang,-3,3))+1,3,0) into id from barang;
  :new.id_barang:=id; 
  
  cekNamaBarang(:new.nama_barang);
 end if;
 
 if(:new.harga_eceran < :new.harga_grosir)then
  raise error_harga;
 end if;
 if(:new.jum_min_grosir<12)then
  raise error_grosir;
 end if;
 
 exception 
  when error_harga then
   raise_application_error(-20001,'Harga Eceran Harus Lebih Mahal Daripada Harga Grosir');
  when error_grosir then
  raise_application_error(-20003,'Jumlah Minimal Grosir Harus Lebih Dari 12');
end;
/

--2
create or replace trigger insertPromo
before insert or update
on promo
for each row
declare
id varchar2(5);
error_tgl exception;
error_diskon exception;
begin
	if inserting then
		id := autogenPromo();
		:new.id_promo:=id;	
        cekPromo(:new.id_barang, :new.tanggal_promo, :new.akhir_promo);
	end if;
	
	if(:new.akhir_promo < :new.tanggal_promo )then
		raise error_tgl;
	end if;
	
	for i in(
        select harga_eceran from barang where id_barang=:new.id_barang
    )loop
		if(:new.potongan_harga > i.harga_eceran) then
        raise error_diskon;
		end if;
    end loop;

	exception 
		when error_tgl then
			raise_application_error(-20001,'Periode diskon tidak valid');
		when error_diskon then
			raise_application_error(-20002,'Potongan melebihi harga barang');
end;
/
--3
create or replace trigger insertCustomer
before insert or update
on customer
for each row
declare
id varchar2(6);
begin
	if inserting then
		id := autogenCustomer();
		:new.id_customer:=id;	
		cekNotelpCust(:new.no_telp);
	end if;
end;
/

--4
create or replace trigger insertPegawai
before insert or update
on pegawai
for each row
declare
id varchar2(5);
begin
	if inserting then
		id := autogenPegawai();
		:new.id_pegawai:=id;		
		cekNotelpPeg(:new.no_telp);
	end if;
end;
/
--5
create or replace trigger UpdateStok
after insert on notajual_body
for each row
declare
	stok number;
	jml number;
begin
	jml := :new.qty;
	
	select jum_barang into stok
	from barang
	where id_barang = :new.id_barang;
	
	stok := stok - jml;
	
	update barang set jum_barang=stok where id_barang=:new.id_barang;
end;
/

commit;