import { TestBed } from '@angular/core/testing';

import { AdminProductsService } from './admin.products.service';

describe('Admin.ProductsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AdminProductsService = TestBed.get(AdminProductsService);
    expect(service).toBeTruthy();
  });
});
