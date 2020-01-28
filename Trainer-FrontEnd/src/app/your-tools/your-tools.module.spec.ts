import { YourToolsModule } from './your-tools.module';

describe('YourToolsModule', () => {
  let yourToolsModule: YourToolsModule;

  beforeEach(() => {
    yourToolsModule = new YourToolsModule();
  });

  it('should create an instance', () => {
    expect(yourToolsModule).toBeTruthy();
  });
});
