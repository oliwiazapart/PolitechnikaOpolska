using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using aventuras.common.Enums;
using aventuras.data.sql.DAO;
using aventuras.data.sql.Extensions;

namespace aventuras.data.sql.Migrations
{
    public class DatabaseSeed
    {
        private readonly AventurasDbContext _context;

        
        public DatabaseSeed(AventurasDbContext context)
        {
            _context = context;
        }


        public void Seed()
        {
            #region CreateUsers
            var userList = BuildUserList();
            _context.User.AddRange(userList);
            _context.SaveChanges();
            #endregion

            #region CreatePosts
            var postList = BuildPostList(userList);
            _context.Post.AddRange(postList);
            _context.SaveChanges();
            #endregion

            #region CreateComments
            var commentList = BuildCommentList();
            _context.Comment.AddRange(commentList);
            _context.SaveChanges();
            #endregion

            #region CreateRatings
            var ratingList = BuildRatingList(postList, userList, commentList);
            _context.Rating.AddRange(ratingList);
            _context.SaveChanges();
            #endregion


            #region CreateVisualMedias
            var visualmediaList = BuildVisualMediaList(postList);
            _context.VisualMedia.AddRange(visualmediaList);
            _context.SaveChanges();
            #endregion

            #region CreateShares
            var shareList = BuildShareList(postList, userList);
            _context.Share.AddRange(shareList);
            _context.SaveChanges();
            #endregion

        }

        private IEnumerable<User> BuildUserList()
        {
            var userList = new List<User>();
            var user = new User()
            {
                Name = "Elle",
                Gender = Gender.Female,
                Email = "elle@epoczta.pl",
                PostNumber = 0,
                BirthDate = new DateTime(1998, 4, 9),
                RegistrationDate = DateTime.Now.AddYears(-1),
                ActiveStatus = true,
                AvatarHref = "https://i.imgur.com/h2Yu0Qb.png"
            };
            userList.Add(user);

            var user2 = new User()
            {
                Name = "Emily",
                Gender = Gender.Female,
                Email = "emily@epoczta.pl",
                PostNumber = 0,
                BirthDate = new DateTime(1988, 12, 7),
                RegistrationDate = DateTime.Now.AddYears(-2),
                ActiveStatus = true,
                AvatarHref = "https://i.imgur.com/JG5dUHj.png"
            };
            userList.Add(user2);

            var user3 = new User()
            {
                Name = "Tia",
                Gender = Gender.Female,
                Email = "tia@epoczta.pl",
                PostNumber = 0,
                BirthDate = new DateTime(2000, 5, 10),
                RegistrationDate = DateTime.Now.AddYears(-1),
                ActiveStatus = true,
                AvatarHref = "https://i.imgur.com/wf3NMCr.png"
            };
            userList.Add(user3);

            var user4 = new User()
            {
                Name = "Alex",
                Gender = Gender.Other,
                Email = "alex@epoczta.pl",
                PostNumber = 0,
                BirthDate = new DateTime(1977, 10, 2),
                RegistrationDate = DateTime.Now.AddYears(-2),
                ActiveStatus = true,
                AvatarHref = "https://i.imgur.com/OUvwhtR.png"
            };
            userList.Add(user4);

            for (int i = 5; i< 20; i++)
            {
                var user5 = new User()
                {
                    Name = "User" + i,
                    Gender = i % 2 == 0 ? Gender.Female : Gender.Male,
                    Email = "user" + i + "@epoczta.pl",
                    PostNumber = 0,
                    BirthDate = new DateTime(1977, 10, 2),
                    RegistrationDate = DateTime.Now.AddYears(-2),
                    ActiveStatus = true,
                    AvatarHref = "https://i.imgur.com/2LRQAJR.png"
                };
                userList.Add(user5);
            }

            return userList;
        }

        private IEnumerable<Post> BuildPostList(IEnumerable<User> userList)
        {
            var postList = new List<Post>();
            for (int i = 0; i < 20; i++)
            {
                postList.Add(new Post
                {
                    CreationDate = DateTime.Now,
                    LastEditDate = DateTime.Now,
                    RatingNumber = 0,
                    CommentsNumber = 0,
                    ActiveStatus = true,
                }) ;
            }

            var rand = new Random();
            var userCount = userList.ToList().Count;
            foreach (var post in postList)
            {
                post.UserId = userList.ToList()[rand.Next(userCount)].UserId;
            }

            return postList;

        }

        private IEnumerable<Comment> BuildCommentList()
        {
            var commentList = new List<Comment>();
            for (int i = 0; i < 10; i++)
            {
                commentList.Add(new Comment
                {
                    CommentBody = "comment"+i,
                    CommentCreationDate = DateTime.Now,
                    CommentEditDate = DateTime.Now,
                    ActiveStatus = true
                });
            }
            return commentList;
        }

        private IEnumerable<Rating> BuildRatingList(IEnumerable<Post> postList,
            IEnumerable<User> userList, IEnumerable<Comment> commentList)
        {
            var ratingList = new List<Rating>();
            var random = new Random();
            var random1 = new Random();
            postList.ToList().Shuffle();
            userList.ToList().Shuffle();
            for (int i = 0; i < commentList.Count(); i++)
            {
                var num = random.Next(0, 10);
                var num1 = random1.Next(1, 10);
                ratingList.Add(new Rating
                {
                    UserId = userList.ToList()[num1].UserId,
                    PostId = postList.ToList()[num1].PostId,
                    CommentId = commentList.ToList()[i].CommentId,
                    NumericRating = num,
                    UsefulStatus = true,
                }); ;

            }
            return ratingList;

        }


        private IEnumerable<VisualMedia> BuildVisualMediaList(IEnumerable<Post> postList)
        {
            var visualmediaList= new List<VisualMedia>();
            postList.ToList().Shuffle();
            for (int i = 0; i < 10; i++)
            {
                var visualmedia = new VisualMedia()
                {
                    PostId = postList.ToList()[i].PostId,
                    VMediaType = MediaType.Image,
                    VMediaHref = "https://i.imgur.com/s0lhcXO.jpg"

                };
                visualmediaList.Add(visualmedia);
            }
                

            for (int i = 10; i < 20; i++)
            {
                var visualmedia2 = new VisualMedia()
                {
                    PostId = postList.ToList()[i].PostId,
                    VMediaType = MediaType.Video,
                    VMediaHref = "https://www.youtube.com/watch?v=_MnD_RGkE2U&ab_channel=PILOTMOVIES"

                };
                visualmediaList.Add(visualmedia2);
            }

            return visualmediaList;
        }


        private IEnumerable<Share> BuildShareList(IEnumerable<Post> postList,
            IEnumerable<User> userList)
        {
            var shareList = new List<Share>();
            postList.ToList().Shuffle();
            for (int i = 0; i < userList.Count(); i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    shareList.Add(new Share
                    {
                        UserId = userList.ToList()[i].UserId,
                        PostId = postList.ToList()[j].PostId
                    });
                }
            }

            return shareList;
        }
    }
}
