import { WritersModule } from './writers.module';

describe('ArticlesWritersModule', () => {
  let articlesWritersModule: WritersModule;

  beforeEach(() => {
    articlesWritersModule = new WritersModule();
  });

  it('should create an instance', () => {
    expect(WritersModule).toBeTruthy();
  });
});
