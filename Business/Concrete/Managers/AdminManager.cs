using Business.Abstract;
using Core.Utilies.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Constants;
using Entities.DTO_s.Requests.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Managers
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;
        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;   
        }

        //CUD Operations
        public async Task<IResult> AddAdmin(AddAdminModel model)
        {
            try
            {
                Admin admin = new Admin()
                {
                    AdminName = model.AdminName,
                    AdminLevel = model.AdminLevel,
                };
                await _adminDal.Add(admin);
                return new ErrorResult(Messages.AddMessages.EXCEPTION_ADDEDADMIN);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<IResult> DeleteAdmin(int id)
        {
            try
            {
                var admin = await _adminDal.Get(p => p.Id == id);
                if (admin != null)
                {
                    await _adminDal.Delete(admin);
                    return new SuccesResult(Messages.DeleteMessages.EXCEPTION_ADMINDELETED);
                }
                else
                {
                    return new ErrorResult(Messages.NotFound.EXCEPTION_ADMINNOTFOUND);
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<IResult> UpdateAdmin(UpdateAdminModel model)
        {
            try
            {
                var admin = await _adminDal.Get(p => p.Id == model.Id);
                if (admin != null)
                {
                    admin.AdminName = model.AdminName;
                    admin.AdminLevel = model.AdminLevel;
                    await _adminDal.Update(admin);
                    return new SuccesResult(Messages.UpdateMessages.EXCEPTION_ADMINUPDATED);
                }
                else
                {
                    return new ErrorResult(Messages.NotFound.EXCEPTION_ADMINNOTFOUND);
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        //***********************************************************

        //Reading Operations

        public async Task<IDataResult<List<Admin>>> GetAll()
        {
            try
            {
                var admins = await _adminDal.GetAll();
                if (admins!=null && admins.Count > 0)
                {
                    return new SuccessDataResult<List<Admin>>(admins,Messages.ReadMessages.EXCEPTION_GETALLADMINS);
                }
                else
                {
                    return new ErrorDataResult<List<Admin>>(Messages.ReadMessages.EXCEPTION_LISTEMPTY);
                }
            }
            catch (Exception e )
            {

                throw e;
            }
        }

        public async Task<IDataResult<List<Admin>>> GetById(int id)
        {
            try
            {
                var admin=await _adminDal.Get(p=> p.Id==id);
                if (admin != null)
                {
                    return new SuccessDataResult<List<Admin>>(new List<Admin>() { admin }, Messages.ReadMessages.EXCEPTION_FOUNDBYIDADMIN);
                }
                else
                {
                    return new ErrorDataResult<List<Admin>>(Messages.NotFound.EXCEPTION_ADMINNOTFOUND);
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }
        
        //************************************************************

        
    }
}
