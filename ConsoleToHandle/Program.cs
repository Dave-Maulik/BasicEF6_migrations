using BasicEF6_migrations;
using DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BasicEF6_migrations.DataBaseClasses;

namespace ConsoleToHandle
{
    class Program
    {
        private static void AddSoldier()
        {
            var soldier = new Soldier()
            {
                Name = "Maulik",
                ServerdInSpecial = false,
                ClanId = 1,
                BirthDate = new DateTime(1993, 3, 4),
            };

            var Soldier1 = new Soldier()
            {
                Name = "Abhishek",
                ServerdInSpecial = true,
                ClanId = 1,
                BirthDate = new DateTime(2001, 5, 5).Date
            };

            var Soldier2 = new Soldier()
            {
                Name = "Meet",
                ServerdInSpecial = true,
                ClanId = 1,
                BirthDate = new DateTime(1998, 6, 12).Date

            };

            using (var context = new SoldierContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Soldiers.AddRange(new List<Soldier> { Soldier1,Soldier2 });
                //context.Soldiers.Add(soldier); For Add One Record
                context.SaveChanges();
            };

        }

        private static void otherQueries()
        {
            using (var context = new SoldierContext())
            {
                context.Database.Log = Console.WriteLine;
                var result = context.Soldiers.Where(u => u.ServerdInSpecial == true).OrderBy(n => n.Id).Take(2).Skip(1) ;
                foreach (var item in result)
                {
                    Console.WriteLine(item.Name);
                }

                /*The Use of GroupBy ServedInSpecial and Printing name and 
                Id of both Group*/

                /*
                var result = context.Soldiers.GroupBy(u => u.ServerdInSpecial);
                foreach (var group in result)
                {
                    Console.WriteLine("Serverd {0}", group.Key);
                    foreach (Soldier s in group)
                    {
                        Console.WriteLine("SoldierName : {0}\n SoldierId : {1}", s.Name, s.Id);
                    }
                }
                */

            }
        }


        private static void UpdateSoldier()
        {
            using (var context = new SoldierContext())
            {
                context.Database.Log = Console.WriteLine;
                var result = context.Soldiers.FirstOrDefault();
                result.ServerdInSpecial = (!result.ServerdInSpecial);
                context.SaveChanges();
            }
        }

        private static void UpdateSoldierDisconnect()
        {
            Soldier soldier;
            using (var context = new SoldierContext())
            {
                context.Database.Log = Console.WriteLine;
                soldier= context.Soldiers.Where(u => u.Name == "Abhishek").FirstOrDefault();
            }

            soldier.Name = "Naman";

            using (var context = new SoldierContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Soldiers.Add(soldier);
                context.Entry(soldier).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        private static void findMetodExample()
        {
            var KeyValue = 2;
            using (var context = new SoldierContext())
            {
                context.Database.Log = Console.WriteLine;
                var result = context.Soldiers.Find(KeyValue);
                Console.WriteLine("1st Visit found Element {0}",result.Name);

                var anotherResult = context.Soldiers.Find(KeyValue);
                Console.WriteLine("2nd Visit found Element {0} ",anotherResult.Name);
            }
        }

        private static void StoredProceduresDemo()
        {
            using (var context = new SoldierContext())
            {
                context.Database.Log = Console.WriteLine;
                var result = context.Soldiers.SqlQuery("GetASoldiers");
                foreach (var item in result)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }

        private static void RemoveSoldierRecord()
        {
            Soldier result;
            using (var context = new SoldierContext())
            {
                context.Database.Log = Console.WriteLine;
                result = context.Soldiers.FirstOrDefault();
                //context.Soldiers.Remove(result);
                //context.SaveChanges();
            }

            using (var contex = new SoldierContext())
            {
                contex.Entry(result).State = EntityState.Deleted;
                contex.SaveChanges();
            }

        }

        private static void DeleteWithFindMethod()
        {
            var keyval = 4;
            using (var context = new SoldierContext())
            {
                context.Database.Log = Console.WriteLine;
                var result = context.Soldiers.Find(keyval);
                context.Soldiers.Remove(result);
                context.SaveChanges();
            }
        }

        private static void DeleteWithStoredProcedure()
        {
            var keyval = 5;
            using (var context = new SoldierContext())
            {
                //Using Context.Database property.
                context.Database.Log = Console.WriteLine;
                context.Database.ExecuteSqlCommand("DeleteSoldier {0}",keyval);
            }
        }

        private static void InsertRelatedData()
        {
            using (var context = new SoldierContext())
            {
                context.Database.Log = Console.WriteLine;
                var soldier4 = new Soldier()
                {
                    Name = "Kobayashi",
                    ServerdInSpecial = false,
                    ClanId = 1,
                    BirthDate = new DateTime(1993, 3, 4),
                };

                var Equip1 = new SoliderEquipment()
                {
                    Name = "AKM",
                    Type = EquipmentType.MachineGun,
                };
                var Equip2 = new SoliderEquipment()
                {
                    Name = "uzi",
                    Type = EquipmentType.SMG,
                };

                context.Soldiers.Add(soldier4);
                soldier4.EquipmentOwned.Add(Equip1);
                soldier4.EquipmentOwned.Add(Equip2);
                context.SaveChanges();
                    
            }
        }

        static void Main(string[] args)
        {
            //to stop EF to going through it's Database Initialization Process when it's working with Soldier Context.
            Database.SetInitializer(new NullDatabaseInitializer<SoldierContext>());
            //AddSoldier();
            //otherQueries();
            //UpdateSoldier(); 
            //findMetodExample();
            //StoredProceduresDemo();
            //RemoveSoldierRecord();
            //DeleteWithFindMethod();
            //DeleteWithStoredProcedure();
            InsertRelatedData();

            Console.ReadKey();
        }
    }
}
