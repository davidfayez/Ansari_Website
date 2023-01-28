using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.Common.Models;
using Ansari_Website.Domain.Entities.Identity;
using Ansari_Website.Domain.Enums;

namespace Ansari_Website.Application.Common.Interfaces;
public interface IAppSettingService : IBaseService<AppSetting>
{
    Task<LookupSearchDto> Search(LookupSearchDto model);
    Task<string> GetAppSettingValue(string Group, String Key, int langId = (int)ELanguages.EN);
    Task<dynamic> GetAppSettingByGroup(string Grup, int langId);
    Task<List<AppSettingDto>> GetSettingValue(int langId);
    Task<int> AddAppSetting(AddAppSettingDto dto);
    Task<bool> updateAppSetting(UpdateAppSettingDto dto);
    Task<UpdateAppSettingDto> GetAppAettingById(int Id);
}
