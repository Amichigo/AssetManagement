import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { Moment } from 'moment';

export class AssetDto
{
    index?: number;
    assetName : string | undefined; 
    assetCode : string | undefined;
    assetType : string | undefined;
    assetGroupName : string | undefined;
    description : string | undefined;
    assetStatus : string | undefined;
    assetValue : number | undefined; 
    supplier : string | undefined;
    addDate : Date | Moment | string | undefined;
    note : string | undefined;
    linkofImage : string | undefined;
    id?: number;
}

export class GetAssetOutput
{
    asset: AssetDto;
    assets: ComboboxItemDto[];

}
