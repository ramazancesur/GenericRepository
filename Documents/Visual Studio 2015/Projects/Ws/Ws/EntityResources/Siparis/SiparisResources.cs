using System;
using System.Collections.Generic;
using System.Linq;
using test2.EntityDao.Employee;
using test2.EntityDao.Order;
using test2.EntityDao.OrderDetails;
using test2.EntityDao.Payment;
using test2.EntityDao.PaymentDetails;
using test2.EntityDao.Price;
using test2.EntityDao.Stock;
using test2.EntityDao.StockDetails;
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
        EmployeeDao empDao;

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
            empDao = new EmployeeDao();
        }


        // Eklenecek
        public List<OdemeDTO> allOdeme()
        {
            return null;
        }
        // Eklenecek
        public List<SiparisDTO> allSiparis()
        {
            return null;
        }
        //Eklenecek
        public List<OdemeDetayDTO> allOdemeDetay(OdemeDTO odeme)
        {
            return null;
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
            OdemeDTO Odeme= updateOdemeDTO(odeme, calisan);
            payment payment = paymentDao.FindBy(x => x.id == odeme.ID&&x.isActive==1).LastOrDefault();

            // ****** Order ******* //
            List<order> lstOrder = orderDao.FindBy(x => x.paymentID == payment.id&&x.isActive==1).ToList();
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
                     List<orderdetail> lstOrderDetail = orderDetailDao.FindBy(x => x.orderID == order.id&&x.isActive==1).ToList();
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
        public SiparisDTO deleteSiparisDTO(SiparisDTO siparis,OdemeDTO odeme,CalisanDTO calisan)
        {
            OdemeDTO Odeme=deleteOdemeDTO(odeme, calisan);
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