import { TestBed, async, inject } from '@angular/core/testing';

import { TrainerGuard } from './trainer.guard';

describe('TrainerGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TrainerGuard]
    });
  });

  it('should ...', inject([TrainerGuard], (guard: TrainerGuard) => {
    expect(guard).toBeTruthy();
  }));
});
