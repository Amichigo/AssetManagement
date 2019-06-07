import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

export class TypeOfAssetDto
{
    assetType: string | undefined;
    id: number;
}

export class GetTypeOfAssetOutput
{
    typeOfAsset: TypeOfAssetDto;
    typeOfAssets: ComboboxItemDto[];

}
