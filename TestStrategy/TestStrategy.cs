using System;

namespace TestStrategy
{

    public class TestStrategy : Strategy.Strategy
    {
        
        public TestStrategy() : base("Estratégia de Teste", "TEST_STRATEGY")
        {         
        }

        public override bool run()
        {
            throw new NotImplementedException();
        }
    }
    
}
