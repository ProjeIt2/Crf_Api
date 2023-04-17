using Core;
using DataAccess.Context;
using DataAccess.Repositories.Interfaces;
using Entities;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{

    public class MetastasisStatusRepository : EntityRepositoryBase<MetastasisStatus, ProjeItContext>, IMetastasisStatusRepository
    {

        public List<MetastasisStatusVM> GetListMetastasisStatuss(int FormID)
        {
            var _result = new List<MetastasisStatusVM>();
            using (var context = new ProjeItContext())
            {
                var result = (from _metasStat in context.MetastasisStatus.Where(x => x.FormID == FormID&&x.Status!=3)
                              join _form in context.Forms on _metasStat.FormID equals _form.ID
                              join _metastasis in context.Metastasis on _metasStat.MetastasisID equals _metastasis.ID
                              join _lymphNode in context.LymphNodes on _metasStat.LymphNodeID equals _lymphNode.ID
                              join _distMet in context.DistantMetastasis on _metasStat.DistantMetastasisID equals _distMet.ID
                              select new MetastasisStatusVM
                              {
                                  ID = _metasStat.ID,
                                  Status=_metasStat.Status,
                                  LymphNoduOperation = _metasStat.LymphNoduOperation,
                                  LymphNoduMetastasis = _metasStat.LymphNoduMetastasis,
                                  DistantMetastasisExist = _metasStat.DistantMetastasisExist,
                                  FormID = _metasStat.FormID,
                                  Barcode = _form.Barcode,
                                  MetastasisID = _metastasis.ID,
                                  MetastasisOrgan = _metastasis.MetastasisOrgan,
                                  LymphLocation = _lymphNode.LymphLocation,
                                  LymphNodeID = _lymphNode.ID,
                                  DistantMetastasisLocation = _distMet.DistantMetastasisLocation,
                                  DistantMetastasisID = _distMet.ID,
                              }).ToList();

                _result = result;


            }
            return _result;
        }

        public MetastasisStatusVM GetListMetastasisStatussID(int id)
        {
            var _result = new MetastasisStatusVM();
            using (var context = new ProjeItContext())
            {
                var result = (from _metasStat in context.MetastasisStatus.Where(x => x.ID == id)
                              join _form in context.Forms on _metasStat.FormID equals _form.ID
                              join _metastasis in context.Metastasis on _metasStat.MetastasisID equals _metastasis.ID
                              join _lymphNode in context.LymphNodes on _metasStat.LymphNodeID equals _lymphNode.ID
                              join _distMet in context.DistantMetastasis on _metasStat.DistantMetastasisID equals _distMet.ID
                              select new MetastasisStatusVM
                              {
                                  ID = _metasStat.ID,
                                  LymphNoduOperation = _metasStat.LymphNoduOperation,
                                  LymphNoduMetastasis = _metasStat.LymphNoduMetastasis,
                                  DistantMetastasisExist = _metasStat.DistantMetastasisExist,
                                  FormID = _metasStat.FormID,
                                  Barcode = _form.Barcode,
                                  MetastasisID = _metastasis.ID,
                                  MetastasisOrgan = _metastasis.MetastasisOrgan,
                                  LymphLocation = _lymphNode.LymphLocation,
                                  LymphNodeID = _lymphNode.ID,
                                  DistantMetastasisLocation = _distMet.DistantMetastasisLocation,
                                  DistantMetastasisID = _distMet.ID,
                              }).FirstOrDefault();

                _result = result;


            }
            return _result;
        }

    }
}
