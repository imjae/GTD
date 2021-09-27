using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 유니티에 직접 사용하기 편하게 제네릭타입과 같이 살짝 개량했습니다.
public abstract class MonsterFactory<T> : MonoBehaviour 
{
    public Monster Spawn(Transform parent, Vector3 spawnPoint)
    {
        // 서브클래서에서 선언한 create 함수 호출 - 서브클래스와 연관된 객체를 소환
        Monster monster = this.Create();
        // 매개변수로 받는 transform을 부모로 설정
        monster.transform.SetParent(parent, false);
        monster.transform.localRotation = Quaternion.Euler(0f, -90f, 0f);
        // 구분을 위해 랜덤한 위치에 생성
        monster.transform.localPosition = spawnPoint;

        return monster;
    }
    // 외부에서 호출하는 함수 - 팩토리내부에서 처리할수있는 모든 처리는 여기서하자.
    public Monster Spawn(T type, Transform parent, Vector3 spawnPoint)
    {
        // 서브클래서에서 선언한 create 함수 호출 - 서브클래스와 연관된 객체를 소환
        Monster monster = this.Create(type);

        // 매개변수로 받는 transform을 부모로 설정
        monster.transform.SetParent(parent, false);

        // 구분을 위해 랜덤한 위치에 생성
        monster.transform.localPosition = spawnPoint; 
        
        return monster;
    }
    // 타입이 다른 몬스터 상관없이 생산
    protected abstract Monster Create();
    // 타입이 다른 몬스터 상관없이 생산
    protected abstract Monster Create(T type); 
}

