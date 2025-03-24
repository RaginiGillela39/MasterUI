import { Component } from "@angular/core";
import { FluidModule } from 'primeng/fluid';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
@Component({
    selector: 'app-organization-type',
    standalone:true,
    imports: [ FluidModule,
                ButtonModule,
                InputTextModule,
    ],
    template: ` 
         <div class="card flex flex-col gap-4">
                    <div class="font-semibold text-xl">Add Organization Type</div>
                    <div class="flex flex-wrap items-start gap-6">
                        <div class="field">
                            <label for="Name" class="sr-only">Name</label>
                            <input pInputText id="Name" type="text" placeholder="Name" />
                        </div>
                        <div class="flex flex-wrap items-start gap-6">
                            <div class="field">
                                <p-button label="Submit" [fluid]="false"></p-button>
                            </div>
                        </div>
        </div>`,
        
    })
  export class AddOrganizationType {}