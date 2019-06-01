import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

export class FormOfRentingAssetDto
{
    formOfRenting: string | undefined;
    id: number;
}

export class GetFormOfRentingAssetOutput
{
    formOfRentingAsset: FormOfRentingAssetDto;
    formOfRentingAssets: ComboboxItemDto[];

}
