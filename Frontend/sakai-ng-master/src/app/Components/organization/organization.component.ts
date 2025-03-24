import { Component, OnInit } from '@angular/core';
import { OrganizationType } from '../../Model/OrganizationType';
import { ServicesService } from '../../Shared/services.service';

@Component({
  selector: 'app-organization',
  imports: [],
  templateUrl: './organization.component.html',
  styleUrl: './organization.component.scss'
})
export class OrganizationComponent implements OnInit {
  private organizationType: any[] = [];
  private selectedOrganizationType: any;
  //private newOrganizationType: new OrganizationType

  constructor(private service:ServicesService){}

  ngOnInit(): void {
    this.getOrganizationType();
  }

   // Fetch the list of OrganizationType (Read)
   getOrganizationType() {
    this.service.getAll<OrganizationType>('OrganizationType').subscribe(
      (data: OrganizationType[]) => {
        this.organizationType = data;
      },
      (error) => {
        console.error('Error fetching OrganizationType:', error);
      }
    );
  }
 // Fetch a specific OrganizationType by ID (Read One)
 getOrganizationTypeById(id: number) {
  this.service.getById<OrganizationType>('OrganizationType', id.toString()).subscribe(
    (data: OrganizationType) => {
      this.selectedOrganizationType = data;
    },
    (error) => {
      console.error('Error fetching OrganizationType:', error);
    }
  );
}

 // Create a new OrganizationType (Create)
 createOrganizationType() {
  this.service.create<OrganizationType>('OrganizationType', this.selectedOrganizationType).subscribe(
    (data) => {
      console.log('Product created:', data);
      this.getOrganizationType();  // Refresh the list of products
    },
    (error) => {
      console.error('Error creating OrganizationType:', error);
    }
  );
}

// Update an existing OrganizationType (Update)
updateOrganizationType() {
  if (this.selectedOrganizationType) {
    this.service.update<OrganizationType>('OrganizationType', this.selectedOrganizationType.id.toString(), 
    this.selectedOrganizationType).subscribe(
      (data) => {
        console.log('OrganizationType updated:', data);
        this.getOrganizationType();  // Refresh the list of products
        this.selectedOrganizationType = null;  // Clear the selected product
      },
      (error) => {
        console.error('Error updating OrganizationType:', error);
      }
    );
  }
}

// Delete a OrganizationType (Delete)
deleteOrganizationType(id: number) {
  this.service.delete('OrganizationType', id.toString()).subscribe(
    (data) => {
      console.log('OrganizationType deleted');
      this.getOrganizationType();  // Refresh the list of products
    },
    (error) => {
      console.error('Error deleting OrganizationType:', error);
    }
  );
}

 // Reset the new product form
 resetForm() {
  //this.newOrganizationType = { id: 0, name: '', description: '', price: 0 };
}

}
