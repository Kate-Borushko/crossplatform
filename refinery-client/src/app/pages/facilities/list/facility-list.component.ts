import { Component, OnInit, ChangeDetectorRef } from '@angular/core'; 
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ApiService } from '../../../services/api.service';
import { Facility } from '../../../models/facility.models';

@Component({
  selector: 'app-facility-list',
  standalone: true,
  imports: [CommonModule, RouterLink, FormsModule],
  templateUrl: './facility-list.component.html'
})
export class FacilityListComponent implements OnInit {
  facilities: Facility[] = [];
  isLoading = false;

  // Фильтры
  searchName: string = '';
  searchType: string = '';
  searchColumnType: string = '';
  sortBy: string = 'Name';
  isDescending: boolean = false;

  constructor(
    private apiService: ApiService,
    private cdr: ChangeDetectorRef 
  ) { }

  ngOnInit(): void {
    this.loadFacilities();
  }

  loadFacilities() {
    this.isLoading = true;
    const params: any = {};

    if (this.searchName) params.Name = this.searchName;
    if (this.searchType) params.Type = this.searchType;
    if (this.searchColumnType) params.ColumnType = this.searchColumnType;
    if (this.sortBy) params.SortBy = this.sortBy;
    params.IsDescending = this.isDescending;

    this.apiService.getFacilities(params).subscribe({
      next: (data) => {
        this.facilities = data;
        this.isLoading = false;
        this.cdr.detectChanges();
      },
      error: (err) => {
        console.error(err);
        this.isLoading = false;
        this.cdr.detectChanges();
      }
    });
  }

  deleteFacility(id: number) {
    if (confirm('Удалить эту установку?')) {
      this.apiService.deleteFacility(id).subscribe({
        next: () => {
          this.loadFacilities();
        },
        error: (err) => {
          console.error(err);
        }
      });
    }
  }

  toggleSort(field: string) {
    if (this.sortBy === field) {
      this.isDescending = !this.isDescending;
    } else {
      this.sortBy = field;
      this.isDescending = false;
    }
    this.loadFacilities();
  }
}
