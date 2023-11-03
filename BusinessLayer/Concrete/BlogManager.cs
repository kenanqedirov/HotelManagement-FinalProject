using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
	public class BlogManager : IBlogService
	{
		private readonly IBlogDAL _blogDAL;

		public BlogManager(IBlogDAL blogDAL)
		{
			_blogDAL = blogDAL;
		}

		public List<Blog> TGetList()
		{
			return _blogDAL.GetList();
		}

		public void TAdd(Blog t)
		{
			_blogDAL.Insert(t);
		}

		public void TDelete(Blog t)
		{
			_blogDAL.Delete(t);
		}

		public Blog TGetById(int id)
		{
			return _blogDAL.GetById(id);
		}

		public void TUpdate(Blog t)
		{
			_blogDAL.Update(t);
		}
	}
}
