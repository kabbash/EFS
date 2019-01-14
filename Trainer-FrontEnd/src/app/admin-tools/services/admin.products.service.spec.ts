import { TestBed } from '@angular/core/testing';

import { Admin.ProductsService } from './admin.products.service';

describe('Admin.ProductsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: Admin.ProductsService = TestBed.get(Admin.ProductsService);
    expect(service).toBeTruthy();
  });
});
