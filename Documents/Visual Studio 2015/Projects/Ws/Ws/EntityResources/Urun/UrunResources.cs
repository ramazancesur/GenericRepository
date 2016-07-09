using System;
using System.Collections.Generic;
using System.Linq;
using test2.EntityDao.Address;
using test2.EntityDao.Contact;
using test2.EntityDao.Firm;
using test2.EntityDao.Price;
using test2.EntityDao.Product;
using test2.EntityDao.ProductList;
using test2.EntityDao.Stock;
using test2.EntityDao.StockDetails;
using Ws.Helper;
using Ws.Model;
using Ws.RestWs.Dto;

namespace Ws.EntityResources.Urun
{
    public class UrunResources
    {
        ProductDao productDao;
        ProductListDao productListDao;
        PriceDao priceDao;
        FirmDao firmDao;
        CreateLog createLog;
        AdressDao addressDao;
        ContactDao contactDao;
        StockDao stockDao;
        StockDetailsDao stockDetailDao;
        public UrunResources()
        {
            init();
        }
        private void init()
        {
            productDao = new ProductDao();
            productListDao = new ProductListDao();
            priceDao = new PriceDao();
            createLog = new CreateLog();
            firmDao = new FirmDao();
            addressDao = new AdressDao();
            contactDao = new ContactDao();
            stockDao = new StockDao();
            stockDetailDao = new StockDetailsDao();
        }
        static UrunDTO urun;
        public List<UrunDTO> getAll(CalisanDTO calisanDTO)
        {
            List<UrunDTO> lstUrunler = new List<UrunDTO>();
            List<product> lstProduct = productDao.FindBy(x => x.isActive == 1).ToList();
            foreach (var product in lstProduct)
            {
                urun = new UrunDTO();
                urun.isActive = 1;
                urun.name = product.name;
                urun.ID = product.id;
                if (product.creationDate.HasValue)
                {
                    urun.createTime = product.creationDate.Value;
                }
                else
                {
                    product.creationDate =urun.createTime;
                    productDao.Edit(product);
                    urun.createTime = DateTime.Now;
                }

                if (product.updateDate.HasValue)
                {
                    urun.updateTime = product.updateDate.Value;
                }
                else
                {
                    product.updateDate = DateTime.Now;
                    productDao.Edit(product);
                    urun.updateTime = DateTime.Now;
                }
                urun.version = 1;
                FirmDTO firmDTO = findByFirm(calisanDTO, urun);
                urun.firmDTO = firmDTO;

                price price = priceDao.FindBy(x => x.productID == product.id && x.isActive == 1).LastOrDefault();
                if (price.price1.HasValue)
                {
                    urun.price = price.price1.Value;
                }
                else
                {
                    price.price1 = 0;
                    priceDao.Edit(price);
                    urun.price = 0;
                }
                firm firm = firmDao.FindBy(x => x.id == firmDTO.ID).FirstOrDefault();
                stock stock = stockDao.FindBy(x => x.firmID == firm.id && x.isActive == 1).LastOrDefault();
                try
                {
                    urun.remain = stockDetailDao.FindBy(x => x.stockID == stock.id && x.isActive == 1).FirstOrDefault().unitSize.Value;
                }
                catch { }
                lstUrunler.Add(urun);
            }
            return lstUrunler;
        }
        private FirmDTO findByFirm(CalisanDTO calisanDTO,UrunDTO urun)
        {
            // ************* Firm Listeleme de de aynısı kullanılacak  *************** //
            firm firm = firmDao.FindBy(x => x.id == calisanDTO.firmID).LastOrDefault();
            FirmDTO firmDTO = new FirmDTO();
            firmDTO.ID = firm.id;
            firmDTO.isActive = 1;
            firmDTO.name = firm.name;

            if (firm.updateDate.HasValue)
            {
                firmDTO.updateTime = firm.updateDate.Value;
            }
            else
            {
                firm.updateDate = DateTime.Now;
                firmDao.Edit(firm);
                urun.updateTime = DateTime.Now;
            }

            if (firm.creationDate.HasValue)
            {
                firmDTO.createTime = firm.creationDate.Value;
            }
            else
            {
                firm.creationDate =urun.createTime;
                firmDao.Edit(firm);
                urun.createTime = DateTime.Now;
            }
            firmDTO.address = addressDao.findById(firm.addressID).address1;
            firmDTO.phoneNumber1 = contactDao.FindBy(x => x.id == firm.contactID).LastOrDefault().value;
            // **************** Firm Listeleme End ****************** //
            return firmDTO;
        }
        public UrunDTO deleteUrunDTO(UrunDTO urunDTO, CalisanDTO createdCalisanDTO,int firmID)
        {
            product product = productDao.FindBy(x => x.id == urunDTO.ID).FirstOrDefault();
            List<productlist> lstProductList = productListDao.FindBy(x => x.productID == product.id && x.isActive == 1).ToList();
            List<price> lstPrice = priceDao.FindBy(x => x.productID == product.id && x.isActive == 1).ToList();
            stock stock = stockDao.FindBy(x => x.firmID == firmID && x.name == product.name && x.isActive == 1).FirstOrDefault();

            product.isActive = 0;
            productDao.Edit(product);
            createLog.SaveLog<product>(createdCalisanDTO, product, 0);
            foreach (var productList in lstProductList)
            {
                productList.isActive = 0;
                productListDao.Edit(productList);
                createLog.SaveLog(createdCalisanDTO, productList, 0);
            }
            foreach (var price in lstPrice)
            {
                price.isActive = 0;
                priceDao.Edit(price);
                createLog.SaveLog(createdCalisanDTO, price, 0);
            }
            stockDao.Edit(stock);

            return urunDTO;
        }
        #region updateUrunDTO
        public UrunDTO updateUrunDTO(UrunDTO urunDTO, CalisanDTO createdCalisanDTO)
        {
            product product = productDao.FindBy(x => x.id == urunDTO.ID).FirstOrDefault();
            List<productlist> lstProductList = productListDao.FindBy(x => x.productID == product.id && x.isActive == 1).ToList();
            price price = new price();
            // ************** Product Guncelleme Işlemi **************** //
            product.name = urunDTO.productName;
            product.updateDate = DateTime.Now;
            productDao.Edit(product);
            createLog.SaveLog<product>(createdCalisanDTO, product, 2);

            // Product List= Product Detail Tablosu  
            //  ************** ProductList Kayıt Işlemi **************** //
            foreach (var productList in lstProductList)
            {
                productList.productID = product.id;
                productList.updateDate = DateTime.Now;
                productList.firmID = urunDTO.firmDTO.ID;
                productListDao.Edit(productList);
                createLog.SaveLog<productlist>(createdCalisanDTO, productList, 2);
            }


            // ************* Price Tablosuna Update İşlemi ************ //
            price.price1 = (float)urunDTO.price;
            price.updateDate = DateTime.Now;
            price.productID = product.id;
            priceDao.Add(price);
            createLog.SaveLog<price>(createdCalisanDTO, price, 2);

            return urunDTO;
        }

        #endregion

        #region createUrunDTO
        public UrunDTO createUrunDTO(UrunDTO urunDTO, CalisanDTO createdCalisanDTO)
        {
            product product = new product();
            productlist productList = new productlist();
            price price = new price();
            stock stock = new stock();
            stockdetail stockDetail = new stockdetail();

            product.isActive = 1;
            productList.isActive = 1;
            price.isActive = 1;
            stock.isActive = 1;
            stockDetail.isActive = 1;

            // ************** Product Kayıt Işlemi **************** //
            product.name = urunDTO.productName;
            product.creationDate = urunDTO.createTime;
            product.updateDate = DateTime.Now;
            productDao.Add(product);
            createLog.SaveLog<product>(createdCalisanDTO, product, 1);

            // Product List= Product Detail Tablosu  
            //  ************** ProductList Kayıt Işlemi **************** //
            productList.productID = product.id;
            productList.creationDate = urunDTO.createTime;
            productList.updateDate = DateTime.Now;
            productList.firmID = urunDTO.firmDTO.ID;
            productListDao.Add(productList);
            createLog.SaveLog<productlist>(createdCalisanDTO, productList, 1);

            // ************* Price Tablosuna Kayıt İşlemi ************ //
            price.creationDate =urunDTO.createTime;
            price.price1 = (float)urunDTO.price;
            price.updateDate = DateTime.Now;
            price.productID = product.id;
            priceDao.Add(price);
            createLog.SaveLog<price>(createdCalisanDTO, price, 1);

            // ************** Stock tablosuna insert ************* //
            stock.firmID = productList.firmID;
            stock.location = urunDTO.firmDTO.address;
            stock.name = product.name;
            stock.creationDate =urunDTO.createTime;
            stock.updateDate = DateTime.Now;
            stockDao.Add(stock);
            createLog.SaveLog(createdCalisanDTO, stock, 1);

            // ********* StockDetail Tablosu insert *********** //

            stockDetail.creationDate =urunDTO.createTime;
            stockDetail.updateDate = DateTime.Now;
            stockDetail.priceID = price.id;
            stockDetail.stockID = stock.id;
            stockDetail.unitSize = 1;
            stockDetail.unitType = 1;
            stockDetailDao.Add(stockDetail);
            createLog.SaveLog(createdCalisanDTO, stockDetail, 1);

            return urunDTO;
        }
        #endregion
    }
}