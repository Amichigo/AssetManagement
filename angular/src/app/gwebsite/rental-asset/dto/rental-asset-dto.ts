import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

export class RentalAssetDto
{
    id: number;
    rentalAssetCode: string;
    assetName: string;
    assetCode: string;
    assetType: string;
    assetGroupName: string;
    assetStatus: string;
    assetValue: number;
    linkofImage : string | undefined;
}

export class GetRentalAssetOutput
{
    rentalAsset: RentalAssetDto;
    listRentalAsset: ComboboxItemDto[];
}
