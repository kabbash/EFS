import { AuthModule } from './auth.module';

describe('ArticlesModule', () => {
  let articlesModule: AuthModule;

  beforeEach(() => {
    articlesModule = new AuthModule();
  });

  it('should create an instance', () => {
    expect(articlesModule).toBeTruthy();
  });
});
