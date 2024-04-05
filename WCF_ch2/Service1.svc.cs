//using System;
//using System.Collections.Generic;
//using System.Diagnostics.Contracts;
//using System.Linq;
//using System.Runtime.Serialization;
//using System.ServiceModel;
//using System.ServiceModel.Web;
//using System.Text;
//using WCF_ch2.Data;
//using WCF_ch2.Models;

//namespace WCF_ch2
//{
//    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
//    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
//    public class Service1 : IService1
//    {
//        public List<UserModel> Services = new List<UserModel>();
//        public List<UserModel> Users = new List<UserModel>();
//        public void DeleteDB(int id)
//        {
//            using (WCFDbContext UData = new UData())
//            {
//                UserModel user = UData.UserModel.FirstOrDefault(u => u.Id == id);
//                if (user != null)
//                {
//                    UData.UserModel.Remove(user);
//                    UData.SaveChanges();
//                }
//            }
//        }

//        public void FirstStartDB()
//        {
//            throw new NotImplementedException();
//        }

//        public string GetData(int value)
//        {
//            return string.Format("You entered: {0}", value);
//        }

//        public CompositeType GetDataUsingDataContract(CompositeType composite)
//        {
//            if (composite == null)
//            {
//                throw new ArgumentNullException("composite");
//            }
//            if (composite.BoolValue)
//            {
//                composite.StringValue += "Suffix";
//            }
//            return composite;
//        }

//        public string Push(int id)
//        {
//            UserModel UserName = Services.Find(find => find.Id == UserModel);

//            return UserName.Name;
//        }

//        public void SecondStartDB()
//        {
//            throw new NotImplementedException();
//        }

//        public List<UserModel> SelectDb()
//        {
//            try
//            {
//                using (WCFDbContext UData = new UData())
//                {
//                    Users = WCFDbContext.UserModel.ToList();
//                }
//            }
//            catch
//            {
//            }
//            return Users;
//        }

//        public UserModel SelectDb1(int id)
//        {
//            UserModel user = null;
//            try
//            {
//                using (WCFDbContext UData = new UData())
//                {
//                    user = UData.UserModel.FirstOrDefault(u => u.Id == id);
//                }
//            }
//            catch (Exception ex)
//            {

//            }
//            return user;
//        }

//        public void Update(UserModel user)
//        {
//            //using (WCFDbContext UData = new UData())
//            //{
//            //    var update = UData.UserModel.FirstOrDefault(i => i.Id == UserModel.Id);
//            //    update.UserName = UserModel.Name;
//            //    UData.SaveChanges();
//            //}
//            try
//            {
//                using (WCFDbContext UData = new UData())
//                {
//                    var update = UData.UserModel.FirstOrDefault(i => i.Id == user.Id);
//                    if (update != null)
//                    {
//                        update.Name = user.Name;
//                        UData.SaveChanges();
//                    }
//                }
//            }
//            catch (Exception ex)
//            {

//            }
//        }
//    }

//}
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WCF_ch2.Data;
using WCF_ch2.Models;

namespace WCF_ch2
{
    public class Service1 : IService1
    {
        public List<UserModel> Services = new List<UserModel>();
        public List<UserModel> Users = new List<UserModel>();

        public void DeleteDB(int id)
        {
            using (WCFDbContext UData = new WCFDbContext())
            {
                UserModel user = UData.UserModel.FirstOrDefault(u => u.Id == id);
                if (user != null)
                {
                    UData.UserModel.Remove(user);
                    UData.SaveChanges();
                }
            }
        }

        public void FirstStartDB()
        {
            // Реализация первоначальной настройки базы данных, если необходимо
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string Push(int id)
        {
            UserModel UserName = Services.Find(find => find.Id == id);

            return UserName.Name;
        }

        public void SecondStartDB()
        {
            // Реализация вторичной настройки базы данных, если необходимо
        }

        public List<UserModel> SelectDb()
        {
            try
            {
                using (WCFDbContext UData = new WCFDbContext())
                {
                    Users = UData.UserModel.ToList();
                }
            }
            catch
            {
                
            }
            return Users;
        }

        public UserModel SelectDb1(int id)
        {
            UserModel user = null;
            try
            {
                using (WCFDbContext UData = new WCFDbContext())
                {
                    user = UData.UserModel.FirstOrDefault(u => u.Id == id);
                }
            }
            catch (Exception ex)
            {
                
            }
            return user;
        }

        public void POST(UserModel user)
        {
            try
            {
                using (WCFDbContext UData = new WCFDbContext())
                {
                    UData.UserModel.Add(user);
                    UData.SaveChanges();

                }
            }
            catch (Exception ex)
            {

            }
        }
        public void Update(UserModel user)
        {
            try
            {
                using (WCFDbContext UData = new WCFDbContext())
                {
                    var update = UData.UserModel.FirstOrDefault(i => i.Id == user.Id);
                    if (update != null)
                    {
                        update.Name = user.Name;
                        UData.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
