using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Algorithm_study.Pattern
{
    /*
        빌더(Builder) [생성 패턴]

        1. 필요성
         - ★ 일단 생성된 객체의 데이터를 변경 없이 읽기 전용으로 써야 하는 경우
         - ★ 생성 시 꼭 입력해야 하는 필수 데이터와 선택적 데이터를 분리하는 경우
         - ★ 생성자가 너무 많아지는 경우

         - 객체와 객체 생성을 분리해야 할 때 사용
         - 특정 데이터를 가진 빌더를 캐싱해두고 빌더를 재사용하여 찍어내는 작업이 필요할 때
           (빌더가 없으면 동일 생성자를 계속 반복 호출해야 하는 경우)

        2. 장점
         - 클래스를 생성할 때 체이닝 방식( .A().B() )을 사용하므로 가독성이 좋다.
         - 생성자를 단 한 개로 유지할 수 있다.
         - 클래스 내에 Setter를 제거할 수 있다.

        3. 단점
         - 클래스의 필드가 변경될 경우 빌더의 필드 및 빌드 메소드도 변경해야 함 -> 이중 변경의 문제
         - 일단 완성된 객체의 데이터를 변경할 수 없으므로, 변경이 필요한 경우 빌더를 호출해야 한다.
    */

    public class Monster
    {
        // 필수 데이터
        public string Name { get; private set; }
        public MonsterKind Kind { get; private set; }

        // 선택적 데이터
        public MonsterColor Color { get; private set; }
        public float Damage { get; private set; }

        // 생성자 하나로 유지
        public Monster(Builder builder)
        {
            this.Name = builder.name;
            this.Kind = builder.kind;
            this.Color = builder.color;
            this.Damage = builder.damage;
        }

        // 내부 빌더 클래스
        public class Builder
        {
            // 필수 데이터
            public string name { get; private set; }
            public MonsterKind kind { get; private set; }

            // 선택적 데이터
            public MonsterColor color { get; private set; }
            public float damage { get; private set; }

            public Builder(string name, MonsterKind kind)
            {
                this.name = name;
                this.kind = kind;
            }

            public Builder Color(MonsterColor color)
            {
                this.color = color;
                return this;
            }

            public Builder Damage(float damage)
            {
                this.damage = damage;
                return this;
            }

            public Monster Build()
            {
                return new Monster(this);
            }
        }
    }

    public enum MonsterKind
    {
        Ground,
        Air
    }
    public enum MonsterColor
    {
        White, Black, Red, Blue
    }

    public static class BuilderTest
    {
        public static void Run()
        {
            // 필수 데이터만 담고 있는 공통 빌더
            Monster.Builder orcBuilder = new Monster.Builder("Orc", MonsterKind.Ground);

            // 다양한 완성 빌더
            Monster.Builder whiteOrcBuilder =
                orcBuilder
                .Color(MonsterColor.White)
                .Damage(1);

            Monster.Builder blackOrcBuilder =
                orcBuilder
                .Color(MonsterColor.Black)
                .Damage(2);

            // 미리 완성된 빌더로 찍어내기
            List<Monster> orcList = new List<Monster>();
            orcList.Add(whiteOrcBuilder.Build());
            orcList.Add(blackOrcBuilder.Build());
            orcList.Add(whiteOrcBuilder.Build());
            orcList.Add(blackOrcBuilder.Build());

            // 선택 데이터만 바꿔서 즉석 찍어내기
            Monster newOrcA = orcBuilder.Color(MonsterColor.Red).Damage(3).Build();
            Monster newOrcB = orcBuilder.Color(MonsterColor.Blue).Damage(4).Build();
        }
    }
}
