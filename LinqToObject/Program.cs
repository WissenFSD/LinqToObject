namespace LinqToObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> stu = new List<Student>();
            stu.Add(new Student()
            {
                Age = 15,
                Name = "Yaşar",
                Surname = "Kemal"
            });
            stu.Add(new Student()
            {
                Age = 12,
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
                Name = "Deniz",
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