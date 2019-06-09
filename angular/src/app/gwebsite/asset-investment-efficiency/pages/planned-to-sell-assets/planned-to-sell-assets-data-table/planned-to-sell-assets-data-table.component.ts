import { Component, OnInit, Input, OnChanges, SimpleChanges, SimpleChange } from '@angular/core';
import moment from 'moment';
import { isDateBetween, addThousandSeparator, sortBy } from '../../../utils';
import { ExcelService } from '../../../utils/excel.service';

@Component({
    selector: 'app-planned-to-sell-assets-data-table',
    templateUrl: './planned-to-sell-assets-data-table.component.html',
    styleUrls: ['./planned-to-sell-assets-data-table.component.css']
})
export class PlannedToSellAssetsDataTableComponent extends Component implements OnChanges {
   @Input() data;
   @Input() generalStatisticsData;
   @Input() timePeriodStartingDate;
   @Input() timePeriodEndingDate;
   @Input() timePeriod;

   private keyword = '';
   private page = 1;
   private pageSize = 10;
   private totalPages = 1;
   private startingDate = moment().format('YYYY-MM-DD');
   private endingDate = moment().format('YYYY-MM-DD');
   private tableData = [];
   private assetTypes = [];
   private dataToExport = [];
   private selectedAssetType = -1;
   private addThousandSeparator = addThousandSeparator;
   private totalAmount;
   private totalQuantity;
   private sortField = 'recordedDate';
   private sortValue = -1;
   private showDetailedPopup = false;
   private detailedRecord;

   constructor(private excelService: ExcelService) {
      // super();
   }

   ngOnChanges(changes: SimpleChanges) {
      const data: SimpleChange = changes.data;
      const generalStatisticsData: SimpleChange = changes.generalStatisticsData;
      const timePeriod: SimpleChange = changes.timePeriod;

      if (data && data.currentValue) {
         this.loadAssetTypes();
         this.loadTableData();
      }

      if (generalStatisticsData && generalStatisticsData.currentValue) {
         this.totalAmount = generalStatisticsData.currentValue[0] && generalStatisticsData.currentValue[0].value;
         this.totalQuantity = generalStatisticsData.currentValue[1] && generalStatisticsData.currentValue[1].value;
      }

      if (timePeriod && timePeriod.currentValue !== timePeriod.previousValue) {
         this.onResetFilters();
      }
   }

   loadTableData() {
      let totalRecords = 0;
      this.dataToExport = [];

      this.tableData = this.data.filter(record => {
         const recordedDate = record['recordedDate'];
         let originalCondition = isDateBetween(moment(new Date(recordedDate)).format('YYYY-MM-DD'), this.timePeriodStartingDate, this.timePeriodEndingDate) && isDateBetween(moment(new Date(recordedDate)).format('YYYY-MM-DD'), this.startingDate, this.endingDate);
         let condition = originalCondition;

         if (parseInt(this.selectedAssetType) !== -1) {
            condition = condition && (record['assetTypeId'] === this.selectedAssetType);
         }
         else {
            condition = originalCondition;
         }

         if (this.keyword !== '') {
            condition = condition && record['assetTypeName'].toLowerCase().includes(this.keyword.toLowerCase());
         }

         if (condition) {
            totalRecords++;
            this.addDataToExport(record);
            return record;
         }
      });

      this.tableData = sortBy(this.tableData, { prop: this.sortField, desc: this.sortValue === -1 });
      this.tableData = this.tableData.slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize - 1);
      this.totalPages = Math.ceil(totalRecords / this.pageSize);
   }

   addDataToExport(record) {
      this.dataToExport.push({
         'Ngày cập nhật': moment(record['recordedDate']).format('DD/MM/YYYY'),
         'Mã nhóm tài sản': record['assetTypeId'],
         'Tên nhóm tài sản': record['assetTypeName'],
         'Số lượng (Tài sản)': addThousandSeparator(record['quantity']),
         'Tỉ lệ % (Số lượng tài sản)': ((record['quantity'] / this.totalQuantity) * 100).toFixed(2),
         'Giá trị đầu tư (VNĐ)': addThousandSeparator(record['amount']),
         'Tỉ lệ % (Giá trị đầu tư)': ((record['amount'] / this.totalAmount) * 100).toFixed(2)
      });
   }

   loadAssetTypes() {
      let assetTypes = [];

      this.data.filter(record => {
         const recordedDate = record['recordedDate'];
         let condition = isDateBetween(moment(new Date(recordedDate)).format('YYYY-MM-DD'), this.timePeriodStartingDate, this.timePeriodEndingDate);

         if (condition) {
            let contained = false;

            contained = assetTypes.find(type => {
               return type['assetTypeId'] === record['assetTypeId'];
            });

            if (!contained) {
               assetTypes.push({ AssetTypeName: record['assetTypeName'], AssetTypeId: record['assetTypeId'] });
            }
         }
      });

      this.assetTypes = assetTypes;
   }

   navigateToPreviousPage() {
      if (this.page > 1) {
         this.page--;
         this.loadTableData();
     }
   }

   navigateToNextPage() {
      if (this.page < this.totalPages) {
         this.page++;
         this.loadTableData();
     }
   }

   onResetFilters() {
      this.startingDate = this.timePeriodStartingDate;
      this.endingDate = this.timePeriodEndingDate;
      this.selectedAssetType = -1;
      this.pageSize = 10;
      this.page = 1;
      this.keyword = '';
      this.totalPages = 1;
      this.loadTableData();
   }

   onExport() {
      this.excelService.exportAsExcelFile(this.dataToExport, 'Thống kê dự kiến thanh lý tài sản');
   }

   onSort(sortField) {
      this.sortField = sortField;
      this.sortValue = this.sortValue * -1;
      this.loadTableData();
   }

   onShowDetailedPopup(record) {
      this.showDetailedPopup = true;
      this.detailedRecord = record;
   }

   onCloseDetailedPopup() {
      this.showDetailedPopup = false;
   }
}