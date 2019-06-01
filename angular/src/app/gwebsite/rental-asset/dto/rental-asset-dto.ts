import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { Moment } from 'moment';

export class RentalAssetDto
{
    index?: number;
    assetName : string | undefined; 
    assetCode : string | undefined;
    description : string | undefined;
    typeOfAsset : string | undefined; 
    assetValue : number | undefined;
    quantity : number | undefined;
    rentalDate : Date | Moment | string | undefined;
    isActive : boolean | undefined;
    linkofImage : string | undefined;
    id?: number;
}

export class GetRentalAssetOutput
{
    rentalAsset: RentalAssetDto;
    rentalAssets: ComboboxItemDto[];

}
