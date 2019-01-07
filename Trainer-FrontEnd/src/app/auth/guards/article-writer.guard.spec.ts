import { TestBed, async, inject } from '@angular/core/testing';

import { ArticleWriterGuard } from './article-writer.guard';

describe('ArticleWriterGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ArticleWriterGuard]
    });
  });

  it('should ...', inject([ArticleWriterGuard], (guard: ArticleWriterGuard) => {
    expect(guard).toBeTruthy();
  }));
});
