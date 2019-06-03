import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { MenuClientComponent } from "@app/gwebsite/menu-client/menu-client.component";
import { DemoModelComponent } from "./demo-model/demo-model.component";
import { CustomerComponent } from "./customer/customer.component";
import { TypeVehicleComponent } from "./typevehicle/typevehicle.component";
import { VehicleComponent } from "./vehicle/vehicle.component";
import { AssetComponent } from "./asset/asset.component";
import { BrandVehicleComponent } from "./brandvehicle/brandvehicle.component";
import { ModelVehicleComponent } from "./modelvehicle/modelvehicle.component";
import { OperateVehicleComponent } from "./operatevehicle/operatevehicle.component";
@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: "",
                children: [
                    {
                        path: "menu-client",
                        component: MenuClientComponent,
                        data: { permission: "Pages.Administration.MenuClient" }
                    }
                ]
            },
            {
                path: "",
                children: [
                    {
                        path: "demo-model",
                        component: DemoModelComponent,
                        data: { permission: "Pages.Administration.DemoModel" }
                    }
                ]
            },
            {
                path: "",
                children: [
                    {
                        path: "customer",
                        component: CustomerComponent,
                        data: { permission: "Pages.Administration.Customer" }
                    }
                ]
            },
            {
                path: "",
                children: [
                    {
                        path: "vehicle",
                        component: VehicleComponent,
                        data: { permission: "Pages.Administration.Vehicle" }
                    }
                ]
            },
            {
                path: "",
                children: [
                    {
                        path: "typevehicle",
                        component: TypeVehicleComponent,
                        data: { permission: "Pages.Administration.TypeVehicle" }
                    }
                ]
            },
            {
                path: "",
                children: [
                    {
                        path: "asset",
                        component: AssetComponent,
                        data: { permission: "Pages.QuanLyXe.Asset" }
                    }
                ]
            },
            {
                path: "",
                children: [
                    {
                        path: "brandvehicle",
                        component: BrandVehicleComponent,
                        data: {
                            permission: "Pages.Administration.BrandVehicle"
                        }
                    }
                ]
            },
            {
                path: "",
                children: [
                    {
                        path: "modelvehicle",
                        component: ModelVehicleComponent,
                        data: {
                            permission: "Pages.Administration.ModelVehicle"
                        }
                    }
                ]
            },
            {
                path: "",
                children: [
                    {
                        path: "operatevehicle",
                        component: OperateVehicleComponent,
                        data: {
                            permission: "Pages.Administration.OperateVehicle"
                        }
                    }
                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class GWebsiteRoutingModule {}
