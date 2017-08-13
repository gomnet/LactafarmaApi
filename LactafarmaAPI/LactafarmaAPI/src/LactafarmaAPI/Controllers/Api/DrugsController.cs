﻿using System;
using System.Collections.Generic;
using System.Linq;
using LactafarmaAPI.Controllers.Api.Base;
using LactafarmaAPI.Controllers.Api.Interfaces;
using LactafarmaAPI.Domain.Models.Base;
using LactafarmaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LactafarmaAPI.Controllers.Api
{
    public class DrugsController : BaseController, IDrugsController
    {
        #region Private Properties

        private readonly ILogger<DrugsController> _logger;

        #endregion

        #region Constructors

        public DrugsController(ILactafarmaService lactafarmaService, IMailService mailService,
            IConfigurationRoot config,
            ILogger<DrugsController> logger, IMemoryCache cache) : base(lactafarmaService, mailService, config, cache)
        {
            _logger = logger;

            CacheInitialize(lactafarmaService.GetAllDrugs(), EntityType.Drug);
        }

        #endregion

        #region Public Methods

        [Route("byname/{startsWith:string}")]
        public JsonResult GetDrugsByName(string startsWith)
        {
            var result = new JsonResult("");
            if (startsWith.Length < 1) return result;

            Cache.TryGetValue(EntityType.Drug, out IEnumerable<BaseModel> drugs);

            result = Json(drugs
                .Where(a => a.VirtualName.IndexOf(startsWith, StringComparison.CurrentCultureIgnoreCase) !=
                            -1).Take(3));

            return result;
        }

        [Route("bygroup/{groupId:int}")]
        public JsonResult GetDrugsByGroup(int groupId)
        {
            var result = new JsonResult(string.Empty);
            try
            {
                _logger.LogInformation("BEGIN GetDrugsByGroup");
                result = Json(LactafarmaService.GetDrugsByGroup(groupId));
                _logger.LogInformation("END GetDrugsByGroup");
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"Exception on JsonResult called GetDrugsByGroup(groupId={groupId}) with message {ex.Message}");
            }

            return result;
        }

        [Route("bybrand/{brandId:int}")]
        public JsonResult GetDrugsByBrand(int brandId)
        {
            var result = new JsonResult(string.Empty);
            try
            {
                _logger.LogInformation("BEGIN GetDrugsByBrand");
                result = Json(LactafarmaService.GetDrugsByBrand(brandId));
                _logger.LogInformation("END GetDrugsByBrand");
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"Exception on JsonResult called GetDrugsByBrand(brandId={brandId}) with message {ex.Message}");
            }

            return result;
        }

        [Route("byalias/{aliasId:int}")]
        public JsonResult GetDrugByAlias(int aliasId)
        {
            var result = new JsonResult(string.Empty);
            try
            {
                _logger.LogInformation("BEGIN GetDrugByAlias");
                result = Json(LactafarmaService.GetDrugByAlias(aliasId));
                _logger.LogInformation("END GetDrugByAlias");
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"Exception on JsonResult called GetDrugByAlias(aliasId={aliasId}) with message {ex.Message}");
            }

            return result;
        }

        [Route("{drugId:int}")]
        public JsonResult GetDrug(int drugId)
        {
            var result = new JsonResult(string.Empty);
            try
            {
                _logger.LogInformation("BEGIN GetDrug");
                result = Json(LactafarmaService.GetDrug(drugId));
                _logger.LogInformation("END GetDrug");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception on JsonResult called GetDrug(drugId={drugId}) with message {ex.Message}");
            }

            return result;
        }

        #endregion
    }
}