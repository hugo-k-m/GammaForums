﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.EntityFrameworkCore;

namespace GammaForums.Service
{
    public class ForumService : IForum
    {
        protected readonly ApplicationDbContext _context;

        public ForumService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task Create(Forum forum)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int forumId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Forum> GetAll()
        {
            return _context.Forums.Include(forum => forum.Posts);
        }

        public IEnumerable<ApplicationUser> GetAllActiveUser()
        {
            throw new NotImplementedException();
        }

        public Forum GetById(int id)
        {
            return _context
            .Forums
            .Where(f => f.Id == id)
            .Include(f => f.Posts)
            .ThenInclude(p => p.User)
            .Include(f => f.Posts)
            .ThenInclude(p => p.Replies)
            .ThenInclude(r => r.User)
            .FirstOrDefault();
        }

        public Task UpdateForumDescription(int forumId, string newDescription)
        {
            throw new NotImplementedException();
        }

        public Task UpdateForumTitle(int forumId, string newTitle)
        {
            throw new NotImplementedException();
        }
    }
}