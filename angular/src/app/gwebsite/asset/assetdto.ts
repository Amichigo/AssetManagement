import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

export class AssetDto
{
    id: number;
    maTaiSan: string;
    tenTaiSan:string;
}

export class GetAssetOutput
{
    asset: AssetDto;
    assets: ComboboxItemDto[];


}
