namespace API.Models
{
    public class UserProfile : User
    {
        public string Image { get; set; }

//        public void test()
//        {
//            FileStream image = System.IO.File.OpenRead("C:\\test\random_image.jpeg");
//            return File(image, "image/jpeg");
//        }
    }
}