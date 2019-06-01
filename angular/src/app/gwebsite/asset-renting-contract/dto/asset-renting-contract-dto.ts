import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { Moment } from 'moment';

export class AssetRentingContractDto
{
    index?: number;
    contractName : string | undefined; 
    contractCode : string | undefined;
    fileCode : string | undefined;
    rentalPartner : string | undefined;
    signDate : Date | Moment | string | undefined;
    linkofImage : string | undefined;
    id?: number;
}

export class GetAssetRentingContractOutput
{
    assetRentingContract: AssetRentingContractDto;
    assetRentingContracts: ComboboxItemDto[];

}
