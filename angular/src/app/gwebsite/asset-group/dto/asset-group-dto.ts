import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { Moment } from 'moment';

export class AssetGroupDto
{
    index?: number;
    assetGroupName : string | undefined; 
    assetGroupCode : string | undefined;
    assetType : string | undefined; 
    id?: number;
}

export class GetAssetGroupOutput
{
    assetGroup: AssetGroupDto;
    assetGroups: ComboboxItemDto[];

}
