import { Component, OnInit } from '@angular/core';
import { OrganizationType } from '../../Model/OrganizationType';
import { ServicesService } from '../../Shared/services.service';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { FormsModule } from '@angular/forms';
import { IconFieldModule } from 'primeng/iconfield';
import { PrimeIcons } from 'primeng/api';
import { Router } from '@angular/router';
import { DialogModule } from 'primeng/dialog';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-organization',
  standalone: true,
  imports: [
    TableModule,
    FormsModule,
    ButtonModule,
    IconFieldModule,
    DialogModule,
    ConfirmDialogModule,
    CommonModule,
  ],
  template: `
    <div class="card">
      <div class="font-semibold text-xl mb-4">Filtering</div>
      <p-table
        #dt1
        [value]="orgType"
        dataKey="id"
        [rows]="10"
        [rowHover]="true"
        [showGridlines]="true"
        [paginator]="true"
        responsiveLayout="scroll"
      >
        <ng-template #caption>
          <div  class="flex justify-end mb-2" iconPosition="right">
            <p-button  label="Add Organization Type" (click)="openDialog()" />
            <p-dialog
              header="Add Organization Type"
              [modal]="true"
              [(visible)]="visible"
              [style]="{ width: '25rem' }"
            >
              <div class="flex items-center gap-4 mb-4">
                <label for="name" class="font-semibold w-24">Name</label>
                <input
                  pInputText
                  id="name"
                  [(ngModel)]="selectedOrganizationType.name"
                  class="flex-auto"
                  autocomplete="off"
                />
              </div>
              <div class="flex justify-end gap-2">
                <p-button label="Cancel" severity="secondary" (click)="cancel()" />
                <p-button label="Save" (click)="saveOrganizationType()" />
              </div>
            </p-dialog>
          </div>
        </ng-template>

        <ng-template #header>
          <tr>
            <th style="min-width: 12rem">
            <div class="flex justify-between items-center flex-column sm:flex-row">
               <div> Name</div>
                <!-- <p-columnFilter
                  type="text"
                  field="name"
                  display="menu"
                  placeholder="Search by name"
                ></p-columnFilter> -->
              <div> Active</div>
              <div iconPosition="right" style="padding: 5px;">Action</div>
              </div>
            </th>
          </tr>
        </ng-template>

        <ng-template #body let-orgType>
          <tr>
            <td>
              <!-- <div class="flex justify-between items-center flex-column sm:flex-row"> -->
              <div class="flex justify-between items-center flex-column sm:flex-row">
                <div class="flex-1">{{ orgType.name }}</div>
                <div class="flex-1 text-center" style="padding: 5px;"> 
                  <i *ngIf="orgType.isActive" class="pi pi-circle-off" style="font-size: 1rem"></i>
                  <i *ngIf="!orgType.isActive" class="pi pi-circle-on" style="font-size: 1rem"></i>
              </div>
                <div class="flex-1 text-center">
                  <p-iconfield class="ml-auto">
                      <div class="flex-1 text-right" style="padding: 5px;">
                        <i class="pi pi-pencil" style="font-size: 1rem" (click)="editOrganizationType(orgType)"></i>
                        <i
                          class="pi pi-times-circle"
                          style="font-size: 1rem"
                          (click)="confirmDelete(orgType.id)" 
                        ></i>
                      </div>
                      <p-dialog
                          header="Confirm Deletion"
                          [modal]="true"
                          [(visible)]="displayDeleteDialog"
                          [style]="{ width: '25rem' }"
                        >
                            <div class="flex items-center gap-4 mb-4">
                              <label for="name" class="font-semibold w-24">Are you sure?</label>
                            </div>
                            <div class="flex justify-end gap-2">
                              <p-button label="Cancel" severity="secondary" (click)="cancelDelete()" />
                              <p-button label="Save" (click)="deleteOrganizationType(orgType.id)" />
                            </div>
                      </p-dialog>
                  </p-iconfield>
                </div>
              </div>
            </td>
          </tr>
        </ng-template>
      </p-table>
    
    </div>
  `,
  styles: [
    `
      .p-datatable-frozen-tbody {
        font-weight: bold;
      }

      .p-datatable-scrollable .p-frozen-column {
        font-weight: bold;
      }
       /* Add specific styles if needed */
       .flex {
        display: flex;
      }

      .justify-end {
        justify-content: flex-end;
      }
    `,
  ],
})
export class Organization implements OnInit {
  public orgType: OrganizationType[] = [];
  public selectedOrganizationType: OrganizationType = {  
    id: '',
    name: '', // Default empty string for Name
    isActive: true,
  };
  visible: boolean = false;
  isEditable: boolean = false;
  displayDeleteDialog: boolean = false;

  constructor(private service: ServicesService, private router: Router) {}

  ngOnInit(): void {
    this.getOrganizationType();
  }

  // Open dialog to add or update Organization Type
  openDialog() {
    this.isEditable = false;
    this.selectedOrganizationType = { id: '', name: '', isActive: false };
    this.visible = true;
    
  }

  confirm() {
    const isConfirmed = window.confirm('Are you sure? Please confirm to proceed.');

    if (isConfirmed) {
      // Action when the user clicks "OK" (Confirmed)
      console.log('You have accepted');
      alert('You have accepted');
    } else {
      // Action when the user clicks "Cancel" (Rejected)
      console.log('You have rejected');
      alert('You have rejected');
    }
    
}
// Confirm delete action
confirmDelete(id: string) {
  this.displayDeleteDialog = true; // Show confirmation dialog
}

  // Save new or updated Organization Type
  saveOrganizationType() {
    if (this.isEditable) {
      if(this.selectedOrganizationType.id!=null)
        this.updateOrganizationType(this.selectedOrganizationType.id);
    } else {
      this.createOrganizationType();
    }
    this.visible = false;
  }

  // Edit Organization Type (prepares data for updating)
  editOrganizationType(orgType: OrganizationType) {
    this.selectedOrganizationType = { ...orgType };
    this.isEditable = true;
    this.visible = true;
  }

  // Create a new OrganizationType (Create)
  createOrganizationType() {
    debugger;
    // Ensure you are passing the object without the id
    const { id, ...organizationToCreate } = this.selectedOrganizationType;  // Exclude id
    this.service.create<OrganizationType>('OrganizationType',organizationToCreate).subscribe(
      (data) => {
        console.log('OrganizationType created:', data);
        this.getOrganizationType(); // Refresh the list of products
      },
      (error) => {
        console.error('Error creating OrganizationType:', error);
      }
    );
  }

  // Update an existing OrganizationType (Update)
  updateOrganizationType(id: string) {
    this.service.update<OrganizationType>('OrganizationType', id, this.selectedOrganizationType).subscribe(
      (data) => {
        console.log('OrganizationType updated:', data);
        this.getOrganizationType(); // Refresh the list of products
      },
      (error) => {
        console.error('Error updating OrganizationType:', error);
      }
    );
  }

  // Delete an OrganizationType (Delete)
  deleteOrganizationType(id: string) {
    debugger;
    this.service.delete('OrganizationType', id).subscribe(
      (data) => {
        console.log('OrganizationType deleted');
        this.getOrganizationType(); // Refresh the list of products
      },
      (error) => {
        console.error('Error deleting OrganizationType:', error);
      }
    );
    this.displayDeleteDialog = false; // Close dialog after delete
  }

   // Cancel delete action
   cancelDelete() {
    this.displayDeleteDialog = false; // Close dialog if user cancels
  }

  // Fetch the list of OrganizationTypes (Read)
  getOrganizationType() {
    this.service.getAll<OrganizationType>('OrganizationType/getAll').subscribe(
      (data: OrganizationType[]) => {
        this.orgType = data;
      },
      (error) => {
        console.error('Error fetching OrganizationTypes:', error);
      }
    );
  }

  // Reset the form after closing dialog (optional)
  cancel() {
    this.visible = false;
    this.selectedOrganizationType = { id: '', name: '', isActive: false };
  }
}
