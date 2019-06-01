import { PermissionCheckerService } from '@abp/auth/permission-checker.service';
import { Injectable } from '@angular/core';
import { AppMenu } from './app-menu';
import { AppMenuItem } from './app-menu-item';

@Injectable()
export class AppNavigationService {

    constructor(private _permissionService: PermissionCheckerService) {

    }

    getMenu(): AppMenu {
        return new AppMenu('MainMenu', 'MainMenu', [
            new AppMenuItem('Dashboard', 'Pages.Administration.Host.Dashboard', 'flaticon-line-graph', '/app/admin/hostDashboard'),
            new AppMenuItem('Dashboard', 'Pages.Tenant.Dashboard', 'flaticon-line-graph', '/app/main/dashboard'),
            new AppMenuItem('Tenants', 'Pages.Tenants', 'flaticon-list-3', '/app/admin/tenants'),
            new AppMenuItem('Editions', 'Pages.Editions', 'flaticon-app', '/app/admin/editions'),
            new AppMenuItem('Administration', '', 'flaticon-interface-8', '', [
                new AppMenuItem('MenuClient', 'Pages.Administration.MenuClient', 'flaticon-menu-1', '/app/gwebsite/menu-client'),
                new AppMenuItem('DemoModel', 'Pages.Administration.DemoModel', 'flaticon-menu-1', '/app/gwebsite/demo-model'),
                new AppMenuItem('Customer', 'Pages.Administration.Customer', 'flaticon-menu-1', '/app/gwebsite/customer'), 
                new AppMenuItem('Quản Lý Bất Động Sản N13', '', 'flaticon-interface-8', '', [
                    new AppMenuItem('Bất Động Sản N13', 'Pages.Administration.QuanLyBatDongSan.BatDongSan', 'flaticon-menu-1', '/app/gwebsite/batdongsan'),
                    new AppMenuItem('Sửa Chữa Bất Động Sản N13', 'Pages.Administration.QuanLyBatDongSan.SuaChuaBatDongSan', 'flaticon-menu-1', '/app/gwebsite/suachuabatdongsan'),
                    new AppMenuItem('Loại Bất Động Sản N13', 'Pages.Administration.QuanLyBatDongSan.LoaiBatDongSan', 'flaticon-menu-1', '/app/gwebsite/loaibatdongsan'),
                    new AppMenuItem('Loại Sở Hữu N13', 'Pages.Administration.QuanLyBatDongSan.LoaiSoHuu', 'flaticon-menu-1', '/app/gwebsite/loaisohuu'),
                    new AppMenuItem('Hiện Trạng Pháp Lý N13', 'Pages.Administration.QuanLyBatDongSan.HienTrangPhapLy', 'flaticon-menu-1', '/app/gwebsite/hientrangphaply'),
                    new AppMenuItem('Tình Trạng Sử Dụng Đất N13', 'Pages.Administration.QuanLyBatDongSan.TinhTrangSuDungDat', 'flaticon-menu-1', '/app/gwebsite/tinhtrangsudungdat'),
                    new AppMenuItem('Tài Sản Test N13', 'Pages.Administration.QuanLyBatDongSan.TaiSan', 'flaticon-menu-1', '/app/gwebsite/taisan'),  
                ]),
                new AppMenuItem('Quản Lý Kế hoạch XD N13', '', 'flaticon-interface-8', '', [
                    new AppMenuItem('Kế hoạch XD cơ bản N13', 'Pages.Administration.QuanLyKeHoachXayDung.KeHoachXayDung', 'flaticon-menu-1', '/app/gwebsite/kehoachxaydung'),
                    
                ]),     
            ]
            ),
         
            new AppMenuItem('Systems', '', 'flaticon-layers', '', [
                new AppMenuItem('OrganizationUnits', 'Pages.Administration.OrganizationUnits', 'flaticon-map', '/app/admin/organization-units'),
                new AppMenuItem('Roles', 'Pages.Administration.Roles', 'flaticon-suitcase', '/app/admin/roles'),
                new AppMenuItem('Users', 'Pages.Administration.Users', 'flaticon-users', '/app/admin/users'),
                new AppMenuItem('Languages', 'Pages.Administration.Languages', 'flaticon-tabs', '/app/admin/languages'),
                new AppMenuItem('AuditLogs', 'Pages.Administration.AuditLogs', 'flaticon-folder-1', '/app/admin/auditLogs'),
                new AppMenuItem('Maintenance', 'Pages.Administration.Host.Maintenance', 'flaticon-lock', '/app/admin/maintenance'),
                new AppMenuItem('Subscription', 'Pages.Administration.Tenant.SubscriptionManagement', 'flaticon-refresh', '/app/admin/subscription-management'),
                new AppMenuItem('VisualSettings', 'Pages.Administration.UiCustomization', 'flaticon-medical', '/app/admin/ui-customization'),
                new AppMenuItem('Settings', 'Pages.Administration.Host.Settings', 'flaticon-settings', '/app/admin/hostSettings'),
                new AppMenuItem('Settings', 'Pages.Administration.Tenant.Settings', 'flaticon-settings', '/app/admin/tenantSettings')
            ]),
            new AppMenuItem('DemoUiComponents', 'Pages.DemoUiComponents', 'flaticon-shapes', '/app/admin/demo-ui-components')
        ]);
    }

    checkChildMenuItemPermission(menuItem): boolean {

        for (let i = 0; i < menuItem.items.length; i++) {
            let subMenuItem = menuItem.items[i];

            if (subMenuItem.permissionName && this._permissionService.isGranted(subMenuItem.permissionName)) {
                return true;
            }

            if (subMenuItem.items && subMenuItem.items.length) {
                return this.checkChildMenuItemPermission(subMenuItem);
            } else if (!subMenuItem.permissionName) {
                return true;
            }
        }

        return false;
    }
}
