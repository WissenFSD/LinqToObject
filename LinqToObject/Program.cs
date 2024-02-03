namespace LinqToObject
{
    internal class Program
    {
        static void Main(string[] args)
        {


            // Linq : bir sorgulama dilidir.

            // Hem veri tabanı hemde c#içerisindeki veri tutan koleksiyon dizi gibi nesnelerin içerisindeki verileri sorgulayabilirsiniz.

            // Avantajlar

            // Sorgularımızı yazarken bize hız kazandırabilir

            // Kodlar bir arada durduğu için okunabilirlik artıyor

            // Linq teknolojisi c# 3.0 ile birlikte hayatımıza girdi.



            // Linq sorguları yazma çeşidinize gre performans artabilir yada azabilir.
            List<Student> stu = new List<Student>();
            stu.Add(new Student()
            {
                Age = 15,
                Name = "Yaşar",
                Surname = "Kemal"
            });
            stu.Add(new Student()
            {
                Age = 15,
                Name = "Oğuzhan",
                Surname = "Dinç"
            });
            stu.Add(new Student()
            {
                Age = 18,
                Name = "Emre",
                Surname = "Çağlar"
            });
            stu.Add(new Student()
            {
                Age = 14,
                Name = "Turan",
                Surname = "Kurtay"
            });
            stu.Add(new Student()
            {
                Age = 11,
                Name = "Yaşar",
                Surname = "Görmüş"
            });


            // klasik yöntem(ismi turan olan student nesnesini getirmek)
            Student student = GetStudentByName(stu, "Turan");
            // linq to object yöntemi

            // Adı turan olan öğrenciler

            Student student1 = stu.Where(n => n.Name == "Turan").FirstOrDefault();

            // Yaşı 14 den büyük olan öğrenciler

            var student2 = stu.Where(s => s.Age >= 50);

            // adı ve soyadı emre çağlar olan kaydı getir


            var student3 = stu.Where(s => s.Name == "Emre" && s.Surname == "Çağlar").FirstOrDefault();


            // ADı girilen bir öğrencinin adı ve soyadını getir

            var student4 = stu.Where(s => s.Name == "Yaşar").Select(k => new
            {
                Ad = k.Name,
                Soyad = k.Surname

            });

            // Örneği farklı yapalım
            var student5 = stu.Where(s => s.Name == "Yaşar").Select(k => new Ogrenci
            {
                Ad = k.Name,
                Soyad = k.Surname

            });



            // en az 10 adet eleman olacak şekilde bir koleksiyon tanımlayın
            // koleksiyonun içerisinde Personel tipi olsun 
            // personel tipinin içerisine 5 adet field yazın

            // fiedler Ad,Soyad,Maas,Departman


            // sorgular

            // Adı Ramazan olan personeli getir
            // Maası 1000 TL'den fazla olan personelleri getir

            // Departmanı Yazılım olan personelleri getir.

            // Maası 3000'den büyük olan personellerin departman adını getir

            //Take metodu vereceğiniz değer kadar elemanı size getirir

            var student6 = stu.Take(2);

            // Any metodu bize bool döner, (Verinin olup olmadığını kontrol etmek için kullanılır)

            // aşağıdaki örnekte, Adı yaşar olan bir eleman var ise true dönecektir

            bool yasarisOk = stu.Any(s => s.Name == "Atilla");


            // OrderByDEscending metodu aldığı parametre ye göre tersten sıralama yapar
            var student7 = stu.OrderByDescending(s => s.Age);


            // OrderBy metodu aldığı parametreye göre düzden sıralama yapar(metinsel ifadelerde alfabetik sıralama yapar)
            var student8 = stu.OrderBy(s => s.Name);


            // Skip metodu, liste içerisinde aldığı değer kadar üyeyi atlamak için kullanılır

            // Örnek : 5 elemanlı bir listeye skip(2) kullanırsak listedeki ilk 2 üye atlanır ve yok sayılır
            var student9 = stu.Skip(2);



            // ToArray metodu, koleksiyonu diziye çevirmek için kullanılır
            Student[] student10 = stu.ToArray();


            // soru : iki yada daha çok metodu peşpeşe kullanabilir miyiz ?

            // önce filtreleme sonra take metodu sonrasında select metodu kullanıldı
            var student11 = stu.Where(s => s.Age == 15).Take(1).Select(m => new
            {
                Ad = m.Name

            });



            // group by

            var student12 = stu.GroupBy(s => s.Age).Select(m => new
            {
                Age = m.Key,
                Count = m.Count(s => s.Age>0)
            });


            var student15 = stu.GroupBy(s => s.Name).Select(m => new
            {

                Name = m.Key,
                Count=m.Count(s=>s.Age>0)

            });

            // Sum

            var student13 = stu.Sum(s => s.Age);

            var student14 = stu.Count(s => s.Age > 0);

        }
        static Student GetStudentByName(List<Student> stu, string name)
        {
            Student turanStudent = null;
            for (int i = 0; i < stu.Count; i++)
            {
                if (stu[i].Name == "Turan")
                {
                    turanStudent = stu[i];

                }
            }
            return turanStudent;
        }
        static Ogrenci ConvertStudentToOgrenci(List<Student> stu, string name)
        {
            Ogrenci yasarOgrenci = null;
            for (int i = 0; i < stu.Count; i++)
            {
                if (stu[i].Name == "Yaşar")
                {
                    yasarOgrenci = new Ogrenci()
                    {

                        Ad = stu[i].Name,
                        Soyad = stu[i].Surname


                    };

                }
            }
            return yasarOgrenci;
        }
    }
}