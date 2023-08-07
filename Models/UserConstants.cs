using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Blog_ASP.Net_Core_6.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() { Username = "jason_admin",
                EmailAddress = "jason.admin@email.com",
                Password = "MyPass_w0rd", 
                Surname = "Bryant",
                Role = "Administrator" ,
                ImageUrl="https://localhost:7086/Images/Profile/admin.jpg",
                Gender = "Male",
                                                          },
            new UserModel() { Username = "elyse_seller", EmailAddress = "elyse.seller@email.com", Password = "MyPass_w0rd", Gender = "Male",Surname = "Lambert", Role = "User",ImageUrl="https://localhost:7086/Images/Profile/admin.jpg"  },
            new UserModel() { Username = "Gopala", EmailAddress = "gopala.vnr@gmail.com", Password = "1234567890", Gender = "Male",  Surname = "Javvadi", Role = "User" ,ImageUrl="https://localhost:7086/Images/Profile/admin.jpg"  },
        };

        public static List<BlogPost> BlogPosts = new List<BlogPost>()
        {
            new BlogPost() {
                BlogId = 1,
                Title = "Great Life",
                EmailAddress = "jason.admin@email.com",
                Content = "Life is a great oppurtunity to Live and Leearn things",
                Image = "https://www.w3schools.com/html/pic_trulli.jpg",
                CreatedBy  = "jason_admin",
                UpdatedBy = null,
                CreatedDate = DateTime.UtcNow.ToLocalTime().ToString("20-June-2023 02:02:02"),
                UpdatedDate =  null,
                Category = "Lifestyle",
             },

            // 2nd record
             new BlogPost() {
                 BlogId = 2,
                 Title = "Wild Life",
                 EmailAddress ="gopala.vnr@email.com",
                 Content = "Wild animals are hunt every day for their food & wound't unless they have hungry and some wild animals are kept in the zoo to take care and to show to the people  && Wild animals are hunt every day for their food & wound't unless they have hungry and some wild animals are kept in the zoo to take care and to show to the people  Wild animals are hunt every day for their food & wound't unless they have hungry and some wild animals are kept in the zoo to take care and to show to the people && Wild animals are hunt every day for their food & wound't unless they have hungry and some wild animals are kept in the zoo to take care and to show to the people && Wild animals are hunt every day for their food & wound't unless they have hungry and some wild animals are kept in the zoo to take care and to show to the people" ,           
                 Image = "https://www.w3schools.com/html/pic_trulli.jpg",
                 CreatedBy  = "Gopala",
                 UpdatedBy = "Gopala",
                 CreatedDate = DateTime.UtcNow.ToLocalTime().ToString("22-June-2023 02:02:02"),
                 UpdatedDate =  null,
                 Category = "Lifestyle",
                
             },
             new BlogPost() {
                BlogId = 3,
                Title = "Learning",
                EmailAddress = "jason.admin@email.com",
                Content = "Learning is oppurtunity  ",
                Image = "https://www.w3schools.com/html/pic_trulli.jpg",
                CreatedBy  = "jason_admin",
                UpdatedBy = null,
                CreatedDate = DateTime.UtcNow.ToLocalTime().ToString("20-June-2023 02:02:02"),
                UpdatedDate =  null,
                Category = "Lifestyle",
             },
             new BlogPost() {
                BlogId = 4,
                Title = "Reading is a Godd habit",
                EmailAddress = "jason.admin@email.com",
                Content = "Reading is knowledge to knoe the important information ",
                Image = "https://www.w3schools.com/html/pic_trulli.jpg",
                CreatedBy  = "jason_admin",
                UpdatedBy = null,
                CreatedDate = DateTime.UtcNow.ToLocalTime().ToString("20-June-2023 02:02:02"),
                UpdatedDate =  null,
                Category = "Lifestyle",
             },
              new BlogPost() {
                BlogId = 4,
                Title = "Reading is a Godd habit",
                EmailAddress = "jason.admin@email.com",
                Content = "Reading is knowledge to knoe the important information ",
                Image = "https://www.w3schools.com/html/pic_trulli.jpg",
                CreatedBy  = "jason_admin",
                UpdatedBy = null,
                CreatedDate = DateTime.UtcNow.ToLocalTime().ToString("20-June-2023 02:02:02"),
                UpdatedDate =  null,
                Category = "Lifestyle",
             },
               new BlogPost() {
                BlogId = 4,
                Title = "Reading is a Godd habit",
                EmailAddress = "jason.admin@email.com",
                Content = "Reading is knowledge to knoe the important information ",
                Image = "https://www.w3schools.com/html/pic_trulli.jpg",
                CreatedBy  = "jason_admin",
                UpdatedBy = null,
                CreatedDate = DateTime.UtcNow.ToLocalTime().ToString("20-June-2023 02:02:02"),
                UpdatedDate =  null,
                Category = "Lifestyle",
             }


         };

        public static List<Comment> Comment = new List<Comment>()
        {
                    new Comment(){
                      Id =1,
                      Content = "This is Good Post",
                      CreatedBy ="jason.admin@email.com",
                      CreatedDate =DateTime.UtcNow.ToLocalTime().ToString("23-June-2023 02:02:02"),
                      BlogId =1,
                      ImageSrc="https://localhost:7086/Images/Profile/admin.jpg",
                      UpdatedBy =null,
                      UpdatedDate =null
                     },
                    new Comment(){
                      Id =2,
                      Content = "This is not a good Post",
                      CreatedBy ="gopala.vnr@gmail.com",
                      CreatedDate = DateTime.UtcNow.ToLocalTime().ToString("24-June-2023 05:02:02"),
                      BlogId =1,
                      UpdatedBy =null,
                      UpdatedDate =null
                     },


                    new Comment(){
                      Id =3,
                      Content = "These wilds are very beautiful and looks cute",
                      CreatedBy ="gopala.vnr@gmail.com",
                      CreatedDate = DateTime.UtcNow.ToLocalTime().ToString("24-June-2023 02:02:02"),
                      BlogId =2,
                       UpdatedBy =null,
                      UpdatedDate =null
                     },
                    new Comment(){
                      Id =4,
                      Content = "This is Good Post",
                        CreatedBy ="gopala.vnr@gmail.com",
                      CreatedDate = DateTime.UtcNow.ToLocalTime().ToString("24-June-2023 04:02:02"),
                      ImageName = "",
                      BlogId =2,
                      UpdatedBy =null,
                      UpdatedDate =null
                     },
                    new Comment(){
                      Id =5,
                      Content = "Wesome",
                        CreatedBy ="gopala.vnr@gmail.com",
                      CreatedDate = DateTime.UtcNow.ToLocalTime().ToString("24-June-2023 03:02:02"),
                      BlogId =2,
                      ImageName = "",
                       UpdatedBy =null,
                      UpdatedDate =null
                     }

        };
    }
}
