import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

export class TypeOfRentalAssetDto
{
    typeOfAsset: string | undefined;
    id: number;
}

export class GetTypeOfRentalAssetOutput
{
    typeOfRentalAsset: TypeOfRentalAssetDto;
    typeOfRentalAssets: ComboboxItemDto[];

}
