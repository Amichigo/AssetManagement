import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { Moment } from 'moment';

export class AssetRentingFileDto
{
    index?: number;
    index1?: number;
    fileName : string | undefined; 
    fileCode : string | undefined;
    assetCode : string | undefined;
    formOfRenting : string | undefined; 
    fileCreatedDate : Date | Moment | string | undefined;
    linkofImage : string | undefined;
    id?: number;
}

export class GetAssetRentingFileOutput
{
    assetRentingFile: AssetRentingFileDto;
    assetRentingFiles: ComboboxItemDto[];

}
