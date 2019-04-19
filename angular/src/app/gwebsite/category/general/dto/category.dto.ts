import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

export class CategoryDto {
    id: number;
    name: string;
    symbol: string;
    description: string;
    categoryType: string;
    categoryId: string;
}

export class GetCategoryOutput {
    category: CategoryDto;
    categorys: ComboboxItemDto[];
}
