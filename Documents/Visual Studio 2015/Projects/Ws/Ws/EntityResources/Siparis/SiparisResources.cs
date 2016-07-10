using System;
using System.Collections.Generic;
using System.Linq;
using test2.EntityDao.Address;
using test2.EntityDao.Client;
using test2.EntityDao.Contact;
using test2.EntityDao.Employee;
using test2.EntityDao.Firm;
using test2.EntityDao.Order;
using test2.EntityDao.OrderDetails;
using test2.EntityDao.Payment;
using test2.EntityDao.PaymentDetails;
using test2.EntityDao.Price;
using test2.EntityDao.Product;
using test2.EntityDao.Stock;
using test2.EntityDao.StockDetails;
using Ws.EntityResources.Musteri;
using Ws.EntityResources.Urun;
using Ws.Helper;
using Ws.Model;
using Ws.RestWs.Dto;

namespace Ws.EntityResources.Siparis
{
    public class SiparisResources
    {
        PaymentDao paymentDao;
        PaymentDetailsDao paymentDetailDao;
        OrderDao orderDao;
        OrderDetailsDao orderDetailDao;

        // İlerde kullamılacak 
        StockDao stockDao;
        StockDetailsDao stockDetailDao;

        CreateLog createLog;
        PriceDao priceDao;
        ClientDao clientDao;
        EmployeeDao empDao;
        AdressDao addressDao;
        ContactDao contactDao;
        FirmDao firmDao;
        ProductDao productDao;
        MusteriResources musteriResources;
        public SiparisResources()
        {
            init();

        }
        private void init()
        {
            paymentDao = new PaymentDao();
            paymentDetailDao = new PaymentDetailsDao();
            orderDao = new OrderDao();
            orderDetailDao = new OrderDetailsDao();
            //  İlerde Kullanılacak
            stockDao = new StockDao();
            stockDetailDao = new StockDetailsDao();

            createLog = new CreateLog();
            priceDao = new PriceDao();
            clientDao = new ClientDao();
            empDao = new EmployeeDao();
            addressDao = new AdressDao();
            contactDao = new ContactDao();
            firmDao = new FirmDao();
            productDao = new ProductDao();
            musteriResources = new MusteriResources();
        }


        // Eklenecek
        public List<OdemeDTO> allOdeme()
        {
            //Main table is payment ; Child table is paymentDetail
            OdemeDTO odemeDTO;
            client client;
            MusteriDTO musteriDTO;
            List<payment> lstPayment = paymentDao.FindBy(x => x.isActive == 1).ToList();
            List<OdemeDTO> lstOdeme = new List<OdemeDTO>();
            foreach (var payment in lstPayment)
            {
                odemeDTO = new OdemeDTO();
                odemeDTO.ID = payment.id;
              
                // *********** Musteri DTO ********* //
                musteriDTO = new MusteriDTO();
                client = new client();
                client = clientDao.FindBy(x => x.id == payment.clientID).FirstOrDefault();
                musteriDTO = musteriResources.findMusteriByClient(client);

                odemeDTO.musteri = musteriDTO;
                #region create and update date
                if (payment.creationDate.HasValue)
                {
                    odemeDTO.createTime = payment.creationDate.Value;
                }
                else
                {
                    payment.creationDate = DateTime.Now;
                    paymentDao.Edit(payment);
                    odemeDTO.createTime = payment.updateDate.Value;
                }
                if (payment.updateDate.HasValue)
                {
                    odemeDTO.updateTime = payment.updateDate.Value;
                }
                else
                {
                    payment.updateDate = DateTime.Now;
                    paymentDao.Edit(payment);
                    odemeDTO.updateTime = payment.updateDate.Value;
                }
                #endregion
                odemeDTO.isActive = 1;
                odemeDTO.name = musteriDTO.name;
                PaymentType paymentType = (PaymentType)Enum.Parse(typeof(PaymentType), payment.paymentType.Value.ToString());
                odemeDTO.paymentType = paymentType;
                odemeDTO.isActive = 1;
                odemeDTO.price = Convert.ToInt32(payment.price);
                lstOdeme.Add(odemeDTO);
            }
            return lstOdeme;
        }
        private CalisanDTO createCalisanDTO(order order)
        {
            firm firm;
            address address;
            CalisanDTO calisan;
            employee emp;

            firm = new firm();
            firm = firmDao.FindBy(x => x.id == order.firmID).FirstOrDefault();
            address = new address();
            address = addressDao.findById(firm.addressID);
            emp = new employee();
            emp = empDao.FindBy(x => x.id == order.employeeID).FirstOrDefault();

            #region CalisanDTO

            calisan = new CalisanDTO();
            calisan.address = address.address1;

            if (emp.creationDate.HasValue)
            {
                calisan.createTime = emp.creationDate.Value;
            }
            else
            {
                emp.creationDate = DateTime.Now;
                empDao.Edit(emp);
                calisan.createTime = emp.creationDate.Value;
            }
            switch (emp.roleID)
            {
                case 1:
                    calisan.employeeType = EmployeeType.PATRON;
                    break;
                case 2:
                    calisan.employeeType = EmployeeType.ISCİ;
                    break;
                case 3:
                    calisan.employeeType = EmployeeType.ARAC;
                    break;
                case 4:
                    calisan.employeeType = EmployeeType.ADMIN;
                    break;
                default:
                    break;
            }
            calisan.firmID = firm.id;
            calisan.id = emp.id;
            calisan.isActive = 1;
            calisan.nameSurname = emp.title + " " + emp.username;
            calisan.passwd = emp.password;
            calisan.roleID = emp.roleID;
            calisan.title = emp.title;
            if (emp.updateDate.HasValue)
            {
                calisan.updateTime = emp.updateDate.Value;
            }
            else
            {
                emp.updateDate = DateTime.Now;
                empDao.Edit(emp);
                calisan.updateTime = emp.updateDate.Value;
            }
            calisan.userName = emp.username;
            calisan.version += 1;
            #endregion
            return calisan;
        }

        private SiparisDetailDTO createSiparisDTO(SiparisDTO siparis, orderdetail orderDetail, CalisanDTO calisanDTO)
        {
            SiparisDetailDTO siparisDetail = new SiparisDetailDTO();
            siparisDetail.ID = orderDetail.id;
            siparisDetail.isActive = 1;
            siparisDetail.createTime = orderDetail.creationDate.Value;
            siparisDetail.updateTime = orderDetail.updateDate.Value;
            siparisDetail.name = siparis.name;
            price price = new price();
            price = priceDao.FindBy(x => x.id == orderDetail.priceID).LastOrDefault();
            siparisDetail.price = price.id;
            if (orderDetail.unitSize.HasValue)
            {
                siparisDetail.unitSize = orderDetail.unitSize.Value;
            }
            if (orderDetail.unitType.HasValue)
            {
                UnitType unitType = (UnitType)Enum.Parse(typeof(PaymentType), orderDetail.unitType.Value.ToString());
                siparisDetail.unitType = unitType;
            }
            product product = new product();
            product = productDao.FindBy(x => x.id == orderDetail.productID).FirstOrDefault();

            UrunDTO urun = new UrunDTO();
            urun.isActive = 1;
            urun.name = product.name;
            urun.ID = product.id;
            if (product.creationDate.HasValue)
            {
                urun.createTime = product.creationDate.Value;
            }
            else
            {
                product.creationDate = urun.createTime;
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
            UrunResources urunResources = new UrunResources();
            FirmDTO firmDTO = urunResources.findByFirm(calisanDTO, urun);
            urun.firmDTO = firmDTO;

            price = priceDao.FindBy(x => x.productID == product.id && x.isActive == 1).LastOrDefault();
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


            siparisDetail.urunDTO = urun;
            return siparisDetail;
        }
        public List<SiparisDetailDTO> allSiparisDetay(SiparisDTO siparis, CalisanDTO calisanDTO)
        {
            List<orderdetail> lstOrderDetail = orderDetailDao.FindBy(x => x.isActive == 1
                                                     && x.orderID == siparis.ID).ToList();
            List<SiparisDetailDTO> lstSiparisDetail = new List<SiparisDetailDTO>();
            SiparisDetailDTO siparisDetail;
            foreach (var orderDetail in lstOrderDetail)
            {
                siparisDetail = new SiparisDetailDTO();
                lstSiparisDetail.Add(siparisDetail);
            }
            return lstSiparisDetail;
        }

        public List<SiparisDTO> allSiparis()
        {
            // List<OdemeDTO> lstOdeme = allOdeme();
            List<SiparisDTO> lstSiparis = new List<SiparisDTO>();
            SiparisDTO siparis;
            CalisanDTO calisan;

            List<order> lstOrder = orderDao.FindBy(x => x.isActive == 1).ToList();
            foreach (var order in lstOrder)
            {
                siparis = new SiparisDTO();
                siparis.ID = order.id;
                calisan = new CalisanDTO();
                calisan = createCalisanDTO(order);

                siparis.createTime = order.creationDate.Value;
                siparis.calisanDTO = calisan;
                siparis.updateTime = order.updateDate.Value;
                siparis.totalAmount = order.totalPrice.Value;
                if (order.deliveryDate.HasValue)
                {
                    siparis.deliveryDate = order.deliveryDate.Value;
                }
                if (order.deliveryStatus.HasValue)
                {
                    DeliveryStatus deliveryStatus = (DeliveryStatus)Enum.Parse(typeof(DeliveryStatus), order.deliveryStatus.Value.ToString());
                    siparis.deliveryStatus = deliveryStatus;
                }
                siparis.isActive = 1;
                /// Siparis Detayı yazılacak
                List<SiparisDetailDTO> lstSiparisDetail = allSiparisDetay(siparis, calisan);
                // siparis.lstSiparisDetail = lstSiparisDetail;
                siparis.totalAmount = order.totalPrice.Value;
                siparis.orderNotesCustom = order.Notes;
                client client = clientDao.FindBy(x => x.id == order.clientID).FirstOrDefault();
                siparis.musteri = musteriResources.findMusteriByClient(client);
                siparis.version = 1;
                lstSiparis.Add(siparis);
            }
            return null;
        }

        //Eklenecek
        public List<OdemeDetayDTO> allOdemeDetay(OdemeDTO odeme)
        {
            OdemeDetayDTO odemeDetay;
            List<OdemeDetayDTO> lstOdemeDetay = new List<OdemeDetayDTO>();
            List<paymentdetail> lstPaymentDetail = paymentDetailDao.FindBy(x => x.paymentID == odeme.ID).ToList();
            foreach (var paymentDetail in lstPaymentDetail)
            {
                odemeDetay = new OdemeDetayDTO();
                odemeDetay.ID = paymentDetail.id;
                #region create and update date
                if (paymentDetail.creationDate.HasValue)
                {
                    odemeDetay.createTime = paymentDetail.creationDate.Value;
                }
                else
                {
                    paymentDetail.creationDate = DateTime.Now;
                    paymentDetailDao.Edit(paymentDetail);
                    odemeDetay.createTime = paymentDetail.updateDate.Value;
                }
                if (paymentDetail.updateDate.HasValue)
                {
                    odemeDetay.updateTime = paymentDetail.updateDate.Value;
                }
                else
                {
                    paymentDetail.updateDate = DateTime.Now;
                    paymentDetailDao.Edit(paymentDetail);
                    odemeDetay.updateTime = paymentDetail.updateDate.Value;
                }
                #endregion
                odemeDetay.isActive = 1;
                odemeDetay.name = odeme.name;
                odemeDetay.newPrice = Convert.ToInt32(paymentDetail.newPrice.Value);
                odemeDetay.oldPrice = Convert.ToInt32(paymentDetail.oldPrice.Value);
                odemeDetay.odeme = odeme;
                odemeDetay.version = odeme.version;
                lstOdemeDetay.Add(odemeDetay);
            }
            return lstOdemeDetay;
        }
        public OdemeDTO deleteOdemeDTO(OdemeDTO odeme, CalisanDTO calisan)
        {
            // ********** Payment *********** //
            payment payment = paymentDao.FindBy(x => x.id == odeme.ID).LastOrDefault();
            payment.isActive = 0;
            payment.updateDate = DateTime.Now;
            createLog.SaveLog(calisan, payment, 0);
            //******* PaymentOrder ******* //
            List<paymentdetail> lstPaymentDetay = paymentDetailDao.FindBy(x => x.paymentID == payment.id).ToList();
            foreach (var paymentDetay in lstPaymentDetay)
            {
                paymentdetail paymentDetail = paymentDetailDao.FindBy(x => x.paymentID == payment.id).LastOrDefault();
                paymentDetail.isActive = 0;
                paymentDetail.updateDate = DateTime.Now;
                paymentDetailDao.Edit(paymentDetail);
                createLog.SaveLog(calisan, paymentDetail, 0);
            }
            return odeme;
        }

        public OdemeDTO updateOdemeDTO(OdemeDTO odeme, CalisanDTO calisan)
        {
            // ********** Payment *********** //
            payment payment = paymentDao.FindBy(x => x.id == odeme.ID).LastOrDefault();
            payment.isActive = 1;
            payment.updateDate = DateTime.Now;
            payment.paymentDate = odeme.createTime;
            payment.clientID = odeme.musteri.ID;
            payment.price = odeme.price;
            payment.remainPrice = odeme.remainCost;
            payment.paymentType = (int)odeme.paymentType;
            paymentDao.Edit(payment);
            createLog.SaveLog(calisan, payment, 2);

            //******* PaymentOrder ******* //
            paymentdetail paymentDetail = paymentDetailDao.FindBy(x => x.paymentID == payment.id).LastOrDefault();
            paymentDetail.isActive = 1;
            paymentDetail.creationDate = odeme.createTime;
            paymentDetail.updateDate = DateTime.Now;
            paymentDetail.paidAmount = odeme.price;
            paymentDetail.paymentID = payment.id;
            paymentDetail.oldPrice = payment.remainPrice;
            paymentDetail.newPrice = paymentDetail.oldPrice - paymentDetail.paidAmount;
            paymentDetailDao.Add(paymentDetail);
            createLog.SaveLog(calisan, paymentDetail, 2);

            return odeme;
        }
        public OdemeDTO createOdeme(OdemeDTO odeme, CalisanDTO calisan)
        {
            // ********** Payment *********** //
            payment payment = paymentDao.FindBy(x => x.id == odeme.ID).LastOrDefault();
            payment.isActive = 1;
            payment.updateDate = DateTime.Now;
            payment.paymentDate = odeme.createTime;
            payment.clientID = odeme.musteri.ID;
            payment.price = odeme.price;
            payment.remainPrice = odeme.remainCost;
            payment.paymentType = (int)odeme.paymentType;
            paymentDao.Edit(payment);
            createLog.SaveLog(calisan, payment, 1);

            //******* PaymentOrder ******* //
            paymentdetail paymentDetail = new paymentdetail();
            paymentDetail.isActive = 1;
            paymentDetail.creationDate = odeme.createTime;
            paymentDetail.updateDate = DateTime.Now;
            paymentDetail.paidAmount = odeme.price;
            paymentDetail.paymentID = payment.id;
            paymentDetail.oldPrice = payment.remainPrice;
            paymentDetail.newPrice = paymentDetail.oldPrice - paymentDetail.paidAmount;
            paymentDetailDao.Add(paymentDetail);
            createLog.SaveLog(calisan, paymentDetail, 1);

            return odeme;
        }

        public SiparisDTO updateSiparisDTO(SiparisDTO siparis, OdemeDTO odeme, CalisanDTO calisan)
        {
            OdemeDTO Odeme = updateOdemeDTO(odeme, calisan);
            payment payment = paymentDao.FindBy(x => x.id == odeme.ID && x.isActive == 1).LastOrDefault();

            // ****** Order ******* //
            List<order> lstOrder = orderDao.FindBy(x => x.paymentID == payment.id && x.isActive == 1).ToList();
            foreach (var order in lstOrder)
            {
                order.updateDate = DateTime.Now;
                order.isActive = 1;
                order.deliveryStatus = (int)siparis.deliveryStatus;
                order.employeeID = siparis.calisanDTO.id;
                order.clientID = siparis.musteri.ID;
                order.totalPrice = siparis.totalAmount;
                order.paymentID = payment.id;
                order.firmID = siparis.calisanDTO.firmID;
                orderDao.Add(order);
                createLog.SaveLog(calisan, order, 1);

                // ********* Order Detail ******* //
                orderdetail orderDetail;
                foreach (var siparisDetail in siparis.lstSiparisDetail)
                {
                    List<orderdetail> lstOrderDetail = orderDetailDao.FindBy(x => x.orderID == order.id && x.isActive == 1).ToList();
                    foreach (var orderDetail2 in lstOrderDetail)
                    {
                        // Yeni bir order detail eklenmiş veya silinmiş olabilir o yüzden silip tekrar oluşturuyorum
                        orderDetailDao.Delete(orderDetail2);
                        createLog.SaveLog(calisan, orderDetail2, 0);
                    }
                    // SiparisDetailden orderdetaile gidecek bir 
                    orderDetail = new orderdetail();
                    orderDetail.updateDate = DateTime.Now;
                    orderDetail.isActive = 1;
                    orderDetail.orderID = order.id;
                    orderDetail.isApproved = 1;
                    orderDetail.amount = Convert.ToInt32(Math.Ceiling(siparisDetail.price));
                    try
                    {
                        orderDetail.priceID = priceDao.FindBy(x => x.productID == siparisDetail.urunDTO.ID).LastOrDefault().id;
                    }
                    catch
                    {
                    }
                    orderDetail.unitSize = siparisDetail.unitSize;
                    orderDetail.unitType = (int)siparisDetail.unitType;
                    orderDetailDao.Add(orderDetail);
                    createLog.SaveLog(calisan, orderDetail, 2);
                }
            }
            return siparis;
        }
        public SiparisDTO deleteSiparisDTO(SiparisDTO siparis, OdemeDTO odeme, CalisanDTO calisan)
        {
            OdemeDTO Odeme = deleteOdemeDTO(odeme, calisan);
            payment payment = paymentDao.FindBy(x => x.id == odeme.ID && x.isActive == 1).LastOrDefault();
            // ****** Order ******* //
            List<order> lstOrder = orderDao.FindBy(x => x.paymentID == payment.id && x.isActive == 1).ToList();
            foreach (var order in lstOrder)
            {
                foreach (var siparisDetail in siparis.lstSiparisDetail)
                {
                    // ************ Order Detail ********** //


                    List<orderdetail> lstOrderDetail = orderDetailDao.FindBy(x => x.orderID == order.id && x.isActive == 1).ToList();
                    foreach (var orderDetail in lstOrderDetail)
                    {
                        orderDetail.updateDate = DateTime.Now;
                        orderDetail.isActive = 0;
                        orderDetailDao.Edit(orderDetail);
                        createLog.SaveLog(calisan, orderDetail, 0);
                    }
                }
                order.isActive = 0;
                order.updateDate = DateTime.Now;
                orderDao.Edit(order);
                createLog.SaveLog(calisan, order, 0);
            }
            return siparis;
        }
        public SiparisDTO createSiparisDTO(SiparisDTO siparis, OdemeDTO odeme, CalisanDTO calisan)
        {
            OdemeDTO Odeme = createOdeme(odeme, calisan);
            payment payment = paymentDao.FindBy(x => x.id == odeme.ID).LastOrDefault();

            // ****** Order ******* //
            order order = new order();
            order.creationDate = siparis.createTime;
            order.updateDate = DateTime.Now;
            order.isActive = 1;
            order.deliveryStatus = (int)siparis.deliveryStatus;
            order.employeeID = siparis.calisanDTO.id;
            order.clientID = siparis.musteri.ID;
            order.totalPrice = siparis.totalAmount;
            order.paymentID = payment.id;
            order.firmID = siparis.calisanDTO.firmID;
            orderDao.Add(order);
            createLog.SaveLog(calisan, order, 1);

            // ********* Order Detail ******* //
            orderdetail orderDetail;
            foreach (var siparisDetail in siparis.lstSiparisDetail)
            {
                orderDetail = new orderdetail();
                orderDetail.creationDate = siparis.createTime;
                orderDetail.updateDate = DateTime.Now;
                orderDetail.isActive = 1;
                orderDetail.orderID = order.id;
                orderDetail.isApproved = 1;
                orderDetail.amount = Convert.ToInt32(Math.Ceiling(siparisDetail.price));
                try
                {
                    orderDetail.priceID = priceDao.FindBy(x => x.productID == siparisDetail.urunDTO.ID).LastOrDefault().id;
                }
                catch
                {
                }
                orderDetail.unitSize = siparisDetail.unitSize;
                orderDetail.unitType = (int)siparisDetail.unitType;
                orderDetailDao.Add(orderDetail);
                createLog.SaveLog(calisan, orderDetail, 1);
            }

            return siparis;
        }
    }
}