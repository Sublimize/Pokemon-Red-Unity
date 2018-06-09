using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AssemblyValues{
public class GlobalRegisters : MonoBehaviour {
		public int testInt;

		//assembly registers;
		public static int a, hl, c, n, b, h, z, bc, l;
		public static string PrintingString;
		//Global Values;
		public static int hItemPrice;
		public static int wWalkBikeSurfState;
		public static int wNumSafariBalls;
		public static int PARTY_LENGTH, wPartyCount;
		public static int MONS_PER_BOX, wNumInBox;
		public static int wcf91;
		public static int wIsInBattle, wBattleType;
		public static int wEnemyMonSpecies;
		public static int wTransformedEnemyMonOriginalDVs, wEnemyMonDVs;
		public static int wEnemyMonStatus, wEnemyBattleStatus3;
		public static int wEnemyMonCatchRate;
		public static int wEnemyMonMaxHP, wEnemyMonHP;
		public static int wCurMap;
		public static int BallFactor2;
		public static int Status2;
		public static int numberOfShakes;
		public static int wPokeBallAnimData;
		public static int wPokeBallCaptureCalcTemp;
		public static bool IsGhostBattle;
		//created variables;
		public static int wActionResultOrTookBattleTurn;
		//ITEM VALUES
		//public static int MASTER_BALL ; INDEX 1
//		public static int ULTRA_BALL    ; 
//		public static int GREAT_BALL    ; 
//		public static int POKE_BALL     ;
//		public static int TOWN_MAP      ; 
//		public static int BICYCLE       ; 
//		public static int SURFBOARD     ; 
//		public static int SAFARI_BALL   ; 
//		public static int POKEDEX       ; 
//		public static int MOON_STONE    ; INDEX 10
//		public static int ANTIDOTE      ; 
//		public static int BURN_HEAL     ;
//		public static int ICE_HEAL      ; 
//		public static int AWAKENING     ; 
//		public static int PARLYZ_HEAL   ;
//		public static int FULL_RESTORE  ; 
//		public static int MAX_POTION    ; 
//		public static int HYPER_POTION  ;
//		public static int SUPER_POTION  ; 
//		public static int POTION        ; INDEX 20
//		public static int BOULDERBADGE  ; INDEX 21
//		public static int CASCADEBADGE  ;  INDEX 22
//		public static int SAFARI_BAIT   ;INDEX 21
//		public static int SAFARI_ROCK   ;INDEX 22
//		public static int THUNDERBADGE  ;
//		public static int RAINBOWBADGE  ;
//		public static int SOULBADGE     ;
//		public static int MARSHBADGE    ; 
//		public static int VOLCANOBADGE  ; 
//		public static int EARTHBADGE    ; 
//		public static int ESCAPE_ROPE   ;
//		public static int REPEL         ; INDEX 30
//		public static int OLD_AMBER     ;
//		public static int FIRE_STONE    ; 
//		public static int THUNDER_STONE ;
//		public static int WATER_STONE   ;
//		public static int HP_UP         ;
//		public static int PROTEIN       ;
//		public static int IRON          ;
//		public static int CARBOS        ; 
//		public static int CALCIUM       ; 
//		public static int RARE_CANDY    ;INDEX 40
//		public static int DOME_FOSSIL   ; 
//		public static int HELIX_FOSSIL  ; 
//		public static int SECRET_KEY    ;
//		public static int UNUSED_ITEM   ;
//		public static int BIKE_VOUCHER  ;
//		public static int X_ACCURACY    ; 
//		public static int LEAF_STONE    ;
//		public static int CARD_KEY      ;
//		public static int NUGGET        ;
//		public static int PP_UP_2       ; INDEX 50
//		public static int POKE_DOLL     ;
//		public static int FULL_HEAL     ; 
//		public static int REVIVE        ; 
//		public static int MAX_REVIVE    ; 
//		public static int GUARD_SPEC    ;
//		public static int SUPER_REPEL   ;
//		public static int MAX_REPEL     ; 
//		public static int DIRE_HIT      ; 
//		public static int COIN          ; 
//		public static int FRESH_WATER   ; INDEX 60
//		public static int SODA_POP      ; 
//		public static int LEMONADE      ; 
//		public static int S_S_TICKET    ; 
//		public static int GOLD_TEETH    ; 
//		public static int X_ATTACK      ; 
//		public static int X_DEFEND      ; 
//		public static int X_SPEED       ;
//		public static int X_SPECIAL     ; 
//		public static int COIN_CASE     ; 
//		public static int OAKS_PARCEL   ; INDEX 70
//		public static int ITEMFINDER    ; 
//		public static int SILPH_SCOPE   ; 
//		public static int POKE_FLUTE    ;
//		public static int LIFT_KEY      ;
//		public static int EXP_ALL       ;
//		public static int OLD_ROD       ;
//		public static int GOOD_ROD      ;
//		public static int SUPER_ROD     ;
//		public static int PP_UP         ;
//		public static int ETHER         ; INDEX 80
//		public static int MAX_ETHER     ;
//		public static int ELIXER        ; 
//		public static int MAX_ELIXER    ;
//		public static int FLOOR_B2F     ;
//		public static int FLOOR_B1F     ;
//		public static int FLOOR_1F      ;
//		public static int FLOOR_2F      ;
//		public static int FLOOR_3F      ;
//		public static int FLOOR_4F      ;
//		public static int FLOOR_5F      ;INDEX 90
//		public static int FLOOR_6F      ;
//		public static int FLOOR_7F      ;
//		public static int FLOOR_8F      ;
//		public static int FLOOR_9F      ;
//		public static int FLOOR_10F     ;
//		public static int FLOOR_11F     ;
//		public static int FLOOR_B4F     ;INDEX 97
//
//
//
//		public static int HM_01         ; INDEX 196
//		public static int HM_02         ; 
//		public static int HM_03         ; 
//		public static int HM_04         ; 
//		public static int HM_05         ; 
//		public static int TM_01         ; 
//		public static int TM_02         ; 
//		public static int TM_03         ; 
//		public static int TM_04         ; 
//		public static int TM_05         ; 
//		public static int TM_06         ; 
//		public static int TM_07         ; 
//		public static int TM_08         ; 
//		public static int TM_09         ;
//		public static int TM_10         ; 
//		public static int TM_11         ; 
//		public static int TM_12         ; 
//		public static int TM_13         ;
//		public static int TM_14         ;
//		public static int TM_15         ;
//		public static int TM_16         ; 
//		public static int TM_17         ; 
//		public static int TM_18         ; 
//		public static int TM_19         ; 
//		public static int TM_20         ; 
//		public static int TM_21         ; 
//		public static int TM_22         ; 
//		public static int TM_23         ;
//		public static int TM_24         ;
//		public static int TM_25         ; 
//		public static int TM_26         ;
//		public static int TM_27         ;
//		public static int TM_28         ;
//		public static int TM_29         ; 
//		public static int TM_30         ; 
//		public static int TM_31         ;
//		public static int TM_32         ; 
//		public static int TM_33         ;
//		public static int TM_34         ; 
//		public static int TM_35         ;
//		public static int TM_36         ;
//		public static int TM_37         ;
//		public static int TM_38         ;
//		public static int TM_39         ;
//		public static int TM_40         ;
//		public static int TM_41         ; 
//		public static int TM_42         ;
//		public static int TM_43         ;
//		public static int TM_44         ;
//		public static int TM_45         ;
//		public static int TM_46         ; 
//		public static int TM_47         ;
//		public static int TM_48         ; 
//		public static int TM_49         ;
//		public static int TM_50         ; //INDEX 250
		//MAP VALUES
//		mapconst PALLET_TOWN,                 9, 10 ; $00
//		mapconst VIRIDIAN_CITY,              18, 20 ; $01
//		mapconst PEWTER_CITY,                18, 20 ; $02
//		mapconst CERULEAN_CITY,              18, 20 ; $03
//		mapconst LAVENDER_TOWN,               9, 10 ; $04
//		mapconst VERMILION_CITY,             18, 20 ; $05
//		mapconst CELADON_CITY,               18, 25 ; $06
//		mapconst FUCHSIA_CITY,               18, 20 ; $07
//		mapconst CINNABAR_ISLAND,             9, 10 ; $08
//		mapconst INDIGO_PLATEAU,              9, 10 ; $09
//		mapconst SAFFRON_CITY,               18, 20 ; $0A
//		mapconst UNUSED_MAP_0B,               0,  0 ; $0B
//		mapconst ROUTE_1,                    18, 10 ; $0C
//		mapconst ROUTE_2,                    36, 10 ; $0D
//		mapconst ROUTE_3,                     9, 35 ; $0E
//		mapconst ROUTE_4,                     9, 45 ; $0F
//		mapconst ROUTE_5,                    18, 10 ; $10
//		mapconst ROUTE_6,                    18, 10 ; $11
//		mapconst ROUTE_7,                     9, 10 ; $12
//		mapconst ROUTE_8,                     9, 30 ; $13
//		mapconst ROUTE_9,                     9, 30 ; $14
//		mapconst ROUTE_10,                   36, 10 ; $15
//		mapconst ROUTE_11,                    9, 30 ; $16
//		mapconst ROUTE_12,                   54, 10 ; $17
//		mapconst ROUTE_13,                    9, 30 ; $18
//		mapconst ROUTE_14,                   27, 10 ; $19
//		mapconst ROUTE_15,                    9, 30 ; $1A
//		mapconst ROUTE_16,                    9, 20 ; $1B
//		mapconst ROUTE_17,                   72, 10 ; $1C
//		mapconst ROUTE_18,                    9, 25 ; $1D
//		mapconst ROUTE_19,                   27, 10 ; $1E
//		mapconst ROUTE_20,                    9, 50 ; $1F
//		mapconst ROUTE_21,                   45, 10 ; $20
//		mapconst ROUTE_22,                    9, 20 ; $21
//		mapconst ROUTE_23,                   72, 10 ; $22
//		mapconst ROUTE_24,                   18, 10 ; $23
//		mapconst ROUTE_25,                    9, 30 ; $24
//		mapconst REDS_HOUSE_1F,               4,  4 ; $25
//		mapconst REDS_HOUSE_2F,               4,  4 ; $26
//		mapconst BLUES_HOUSE,                 4,  4 ; $27
//		mapconst OAKS_LAB,                    6,  5 ; $28
//		mapconst VIRIDIAN_POKECENTER,         4,  7 ; $29
//		mapconst VIRIDIAN_MART,               4,  4 ; $2A
//		mapconst VIRIDIAN_SCHOOL,             4,  4 ; $2B
//		mapconst VIRIDIAN_HOUSE,              4,  4 ; $2C
//		mapconst VIRIDIAN_GYM,                9, 10 ; $2D
//		mapconst DIGLETTS_CAVE_EXIT,          4,  4 ; $2E
//		mapconst VIRIDIAN_FOREST_EXIT,        4,  5 ; $2F
//		mapconst ROUTE_2_HOUSE,               4,  4 ; $30
//		mapconst ROUTE_2_GATE,                4,  5 ; $31
//		mapconst VIRIDIAN_FOREST_ENTRANCE,    4,  5 ; $32
//		mapconst VIRIDIAN_FOREST,            24, 17 ; $33
//		mapconst MUSEUM_1F,                   4, 10 ; $34
//		mapconst MUSEUM_2F,                   4,  7 ; $35
//		mapconst PEWTER_GYM,                  7,  5 ; $36
//		mapconst PEWTER_HOUSE_1,              4,  4 ; $37
//		mapconst PEWTER_MART,                 4,  4 ; $38
//		mapconst PEWTER_HOUSE_2,              4,  4 ; $39
//		mapconst PEWTER_POKECENTER,           4,  7 ; $3A
//		mapconst MT_MOON_1,                  18, 20 ; $3B
//		mapconst MT_MOON_2,                  14, 14 ; $3C
//		mapconst MT_MOON_3,                  18, 20 ; $3D
//		mapconst TRASHED_HOUSE,               4,  4 ; $3E
//		mapconst CERULEAN_HOUSE_1,            4,  4 ; $3F
//		mapconst CERULEAN_POKECENTER,         4,  7 ; $40
//		mapconst CERULEAN_GYM,                7,  5 ; $41
//		mapconst BIKE_SHOP,                   4,  4 ; $42
//		mapconst CERULEAN_MART,               4,  4 ; $43
//		mapconst MT_MOON_POKECENTER,          4,  7 ; $44
//		mapconst TRASHED_HOUSE_COPY,          4,  4 ; $45
//		mapconst ROUTE_5_GATE,                3,  4 ; $46
//		mapconst PATH_ENTRANCE_ROUTE_5,       4,  4 ; $47
//		mapconst DAYCAREM,                    4,  4 ; $48
//		mapconst ROUTE_6_GATE,                3,  4 ; $49
//		mapconst PATH_ENTRANCE_ROUTE_6,       4,  4 ; $4A
//		mapconst PATH_ENTRANCE_ROUTE_6_COPY,  4,  4 ; $4B
//		mapconst ROUTE_7_GATE,                4,  3 ; $4C
//		mapconst PATH_ENTRANCE_ROUTE_7,       4,  4 ; $4D
//		mapconst PATH_ENTRANCE_ROUTE_7_COPY,  4,  4 ; $4E
//		mapconst ROUTE_8_GATE,                4,  3 ; $4F
//		mapconst PATH_ENTRANCE_ROUTE_8,       4,  4 ; $50
//		mapconst ROCK_TUNNEL_POKECENTER,      4,  7 ; $51
//		mapconst ROCK_TUNNEL_1,              18, 20 ; $52
//		mapconst POWER_PLANT,                18, 20 ; $53
//		mapconst ROUTE_11_GATE_1F,            5,  4 ; $54
//		mapconst DIGLETTS_CAVE_ENTRANCE,      4,  4 ; $55
//		mapconst ROUTE_11_GATE_2F,            4,  4 ; $56
//		mapconst ROUTE_12_GATE_1F,            4,  5 ; $57
//		mapconst BILLS_HOUSE,                 4,  4 ; $58
//		mapconst VERMILION_POKECENTER,        4,  7 ; $59
//		mapconst POKEMON_FAN_CLUB,            4,  4 ; $5A
//		mapconst VERMILION_MART,              4,  4 ; $5B
//		mapconst VERMILION_GYM,               9,  5 ; $5C
//		mapconst VERMILION_HOUSE_1,           4,  4 ; $5D
//		mapconst VERMILION_DOCK,              6, 14 ; $5E
//		mapconst SS_ANNE_1,                   9, 20 ; $5F
//		mapconst SS_ANNE_2,                   9, 20 ; $60
//		mapconst SS_ANNE_3,                   3, 10 ; $61
//		mapconst SS_ANNE_4,                   4, 15 ; $62
//		mapconst SS_ANNE_5,                   7, 10 ; $63
//		mapconst SS_ANNE_6,                   8,  7 ; $64
//		mapconst SS_ANNE_7,                   4,  3 ; $65
//		mapconst SS_ANNE_8,                   8, 12 ; $66
//		mapconst SS_ANNE_9,                   8, 12 ; $67
//		mapconst SS_ANNE_10,                  8, 12 ; $68
//		mapconst UNUSED_MAP_69,               0,  0 ; $69
//		mapconst UNUSED_MAP_6A,               0,  0 ; $6A
//		mapconst UNUSED_MAP_6B,               0,  0 ; $6B
//		mapconst VICTORY_ROAD_1,              9, 10 ; $6C
//		mapconst UNUSED_MAP_6D,               0,  0 ; $6D
//		mapconst UNUSED_MAP_6E,               0,  0 ; $6E
//		mapconst UNUSED_MAP_6F,               0,  0 ; $6F
//		mapconst UNUSED_MAP_70,               0,  0 ; $70
//		mapconst LANCES_ROOM,                13, 13 ; $71
//		mapconst UNUSED_MAP_72,               0,  0 ; $72
//		mapconst UNUSED_MAP_73,               0,  0 ; $73
//		mapconst UNUSED_MAP_74,               0,  0 ; $74
//		mapconst UNUSED_MAP_75,               0,  0 ; $75
//		mapconst HALL_OF_FAME,                4,  5 ; $76
//		mapconst UNDERGROUND_PATH_NS,        24,  4 ; $77
//		mapconst CHAMPIONS_ROOM,              4,  4 ; $78
//		mapconst UNDERGROUND_PATH_WE,         4, 25 ; $79
//		mapconst CELADON_MART_1,              4, 10 ; $7A
//		mapconst CELADON_MART_2,              4, 10 ; $7B
//		mapconst CELADON_MART_3,              4, 10 ; $7C
//		mapconst CELADON_MART_4,              4, 10 ; $7D
//		mapconst CELADON_MART_ROOF,           4, 10 ; $7E
//		mapconst CELADON_MART_ELEVATOR,       2,  2 ; $7F
//		mapconst CELADON_MANSION_1,           6,  4 ; $80
//		mapconst CELADON_MANSION_2,           6,  4 ; $81
//		mapconst CELADON_MANSION_3,           6,  4 ; $82
//		mapconst CELADON_MANSION_4,           6,  4 ; $83
//		mapconst CELADON_MANSION_5,           4,  4 ; $84
//		mapconst CELADON_POKECENTER,          4,  7 ; $85
//		mapconst CELADON_GYM,                 9,  5 ; $86
//		mapconst GAME_CORNER,                 9, 10 ; $87
//		mapconst CELADON_MART_5,              4, 10 ; $88
//		mapconst CELADON_PRIZE_ROOM,          4,  5 ; $89
//		mapconst CELADON_DINER,               4,  5 ; $8A
//		mapconst CELADON_HOUSE,               4,  4 ; $8B
//		mapconst CELADON_HOTEL,               4,  7 ; $8C
//		mapconst LAVENDER_POKECENTER,         4,  7 ; $8D
//		mapconst POKEMONTOWER_1,              9, 10 ; $8E
//		mapconst POKEMONTOWER_2,              9, 10 ; $8F
//		mapconst POKEMONTOWER_3,              9, 10 ; $90
//		mapconst POKEMONTOWER_4,              9, 10 ; $91
//		mapconst POKEMONTOWER_5,              9, 10 ; $92
//		mapconst POKEMONTOWER_6,              9, 10 ; $93
//		mapconst POKEMONTOWER_7,              9, 10 ; $94
//		mapconst LAVENDER_HOUSE_1,            4,  4 ; $95
//		mapconst LAVENDER_MART,               4,  4 ; $96
//		mapconst LAVENDER_HOUSE_2,            4,  4 ; $97
//		mapconst FUCHSIA_MART,                4,  4 ; $98
//		mapconst FUCHSIA_HOUSE_1,             4,  4 ; $99
//		mapconst FUCHSIA_POKECENTER,          4,  7 ; $9A
//		mapconst FUCHSIA_HOUSE_2,             4,  5 ; $9B
//		mapconst SAFARI_ZONE_ENTRANCE,        3,  4 ; $9C
//		mapconst FUCHSIA_GYM,                 9,  5 ; $9D
//		mapconst FUCHSIA_MEETING_ROOM,        4,  7 ; $9E
//		mapconst SEAFOAM_ISLANDS_2,           9, 15 ; $9F
//		mapconst SEAFOAM_ISLANDS_3,           9, 15 ; $A0
//		mapconst SEAFOAM_ISLANDS_4,           9, 15 ; $A1
//		mapconst SEAFOAM_ISLANDS_5,           9, 15 ; $A2
//		mapconst VERMILION_HOUSE_2,           4,  4 ; $A3
//		mapconst FUCHSIA_HOUSE_3,             4,  4 ; $A4
//		mapconst MANSION_1,                  14, 15 ; $A5
//		mapconst CINNABAR_GYM,                9, 10 ; $A6
//		mapconst CINNABAR_LAB_1,              4,  9 ; $A7
//		mapconst CINNABAR_LAB_2,              4,  4 ; $A8
//		mapconst CINNABAR_LAB_3,              4,  4 ; $A9
//		mapconst CINNABAR_LAB_4,              4,  4 ; $AA
//		mapconst CINNABAR_POKECENTER,         4,  7 ; $AB
//		mapconst CINNABAR_MART,               4,  4 ; $AC
//		mapconst CINNABAR_MART_COPY,          4,  4 ; $AD
//		mapconst INDIGO_PLATEAU_LOBBY,        6,  8 ; $AE
//		mapconst COPYCATS_HOUSE_1F,           4,  4 ; $AF
//		mapconst COPYCATS_HOUSE_2F,           4,  4 ; $B0
//		mapconst FIGHTING_DOJO,               6,  5 ; $B1
//		mapconst SAFFRON_GYM,                 9, 10 ; $B2
//		mapconst SAFFRON_HOUSE_1,             4,  4 ; $B3
//		mapconst SAFFRON_MART,                4,  4 ; $B4
//		mapconst SILPH_CO_1F,                 9, 15 ; $B5
//		mapconst SAFFRON_POKECENTER,          4,  7 ; $B6
//		mapconst SAFFRON_HOUSE_2,             4,  4 ; $B7
//		mapconst ROUTE_15_GATE_1F,            5,  4 ; $B8
//		mapconst ROUTE_15_GATE_2F,            4,  4 ; $B9
//		mapconst ROUTE_16_GATE_1F,            7,  4 ; $BA
//		mapconst ROUTE_16_GATE_2F,            4,  4 ; $BB
//		mapconst ROUTE_16_HOUSE,              4,  4 ; $BC
//		mapconst ROUTE_12_HOUSE,              4,  4 ; $BD
//		mapconst ROUTE_18_GATE_1F,            5,  4 ; $BE
//		mapconst ROUTE_18_GATE_2F,            4,  4 ; $BF
//		mapconst SEAFOAM_ISLANDS_1,           9, 15 ; $C0
//		mapconst ROUTE_22_GATE,               4,  5 ; $C1
//		mapconst VICTORY_ROAD_2,              9, 15 ; $C2
//		mapconst ROUTE_12_GATE_2F,            4,  4 ; $C3
//		mapconst VERMILION_HOUSE_3,           4,  4 ; $C4
//		mapconst DIGLETTS_CAVE,              18, 20 ; $C5
//		mapconst VICTORY_ROAD_3,              9, 15 ; $C6
//		mapconst ROCKET_HIDEOUT_1,           14, 15 ; $C7
//		mapconst ROCKET_HIDEOUT_2,           14, 15 ; $C8
//		mapconst ROCKET_HIDEOUT_3,           14, 15 ; $C9
//		mapconst ROCKET_HIDEOUT_4,           12, 15 ; $CA
//		mapconst ROCKET_HIDEOUT_ELEVATOR,     4,  3 ; $CB
//		mapconst UNUSED_MAP_CC,               0,  0 ; $CC
//		mapconst UNUSED_MAP_CD,               0,  0 ; $CD
//		mapconst UNUSED_MAP_CE,               0,  0 ; $CE
//		mapconst SILPH_CO_2F,                 9, 15 ; $CF
//		mapconst SILPH_CO_3F,                 9, 15 ; $D0
//		mapconst SILPH_CO_4F,                 9, 15 ; $D1
//		mapconst SILPH_CO_5F,                 9, 15 ; $D2
//		mapconst SILPH_CO_6F,                 9, 13 ; $D3
//		mapconst SILPH_CO_7F,                 9, 13 ; $D4
//		mapconst SILPH_CO_8F,                 9, 13 ; $D5
//		mapconst MANSION_2,                  14, 15 ; $D6
//		mapconst MANSION_3,                   9, 15 ; $D7
//		mapconst MANSION_4,                  14, 15 ; $D8
//		mapconst SAFARI_ZONE_EAST,           13, 15 ; $D9
//		mapconst SAFARI_ZONE_NORTH,          18, 20 ; $DA
//		mapconst SAFARI_ZONE_WEST,           13, 15 ; $DB
//		mapconst SAFARI_ZONE_CENTER,         13, 15 ; $DC
//		mapconst SAFARI_ZONE_REST_HOUSE_1,    4,  4 ; $DD
//		mapconst SAFARI_ZONE_SECRET_HOUSE,    4,  4 ; $DE
//		mapconst SAFARI_ZONE_REST_HOUSE_2,    4,  4 ; $DF
//		mapconst SAFARI_ZONE_REST_HOUSE_3,    4,  4 ; $E0
//		mapconst SAFARI_ZONE_REST_HOUSE_4,    4,  4 ; $E1
//		mapconst UNKNOWN_DUNGEON_2,           9, 15 ; $E2
//		mapconst UNKNOWN_DUNGEON_3,           9, 15 ; $E3
//		mapconst UNKNOWN_DUNGEON_1,           9, 15 ; $E4
//		mapconst NAME_RATERS_HOUSE,           4,  4 ; $E5
//		mapconst CERULEAN_HOUSE_2,            4,  4 ; $E6
//		mapconst UNUSED_MAP_E7,               0,  0 ; $E7
//		mapconst ROCK_TUNNEL_2,              18, 20 ; $E8
//		mapconst SILPH_CO_9F,                 9, 13 ; $E9
//		mapconst SILPH_CO_10F,                9,  8 ; $EA
//		mapconst SILPH_CO_11F,                9,  9 ; $EB
//		mapconst SILPH_CO_ELEVATOR,           2,  2 ; $EC
//		mapconst UNUSED_MAP_ED,               0,  0 ; $ED
//		mapconst UNUSED_MAP_EE,               0,  0 ; $EE
//		mapconst TRADE_CENTER,                4,  5 ; $EF
//		mapconst COLOSSEUM,                   4,  5 ; $F0
//		mapconst UNUSED_MAP_F1,               0,  0 ; $F1
//		mapconst UNUSED_MAP_F2,               0,  0 ; $F2
//		mapconst UNUSED_MAP_F3,               0,  0 ; $F3
//		mapconst UNUSED_MAP_F4,               0,  0 ; $F4
//		mapconst LORELEIS_ROOM,               6,  5 ; $F5
//		mapconst BRUNOS_ROOM,                 6,  5 ; $F6
//		mapconst AGATHAS_ROOM,                6,  5 ; $F7
//
		//MON indexes
//		const RHYDON       ; $01
//		const KANGASKHAN   ; $02
//		const NIDORAN_M    ; $03
//		const CLEFAIRY     ; $04
//		const SPEAROW      ; $05
//		const VOLTORB      ; $06
//		const NIDOKING     ; $07
//		const SLOWBRO      ; $08
//		const IVYSAUR      ; $09
//		const EXEGGUTOR    ; $0A
//		const LICKITUNG    ; $0B
//		const EXEGGCUTE    ; $0C
//		const GRIMER       ; $0D
//		const GENGAR       ; $0E
//		const NIDORAN_F    ; $0F
//		const NIDOQUEEN    ; $10
//		const CUBONE       ; $11
//		const RHYHORN      ; $12
//		const LAPRAS       ; $13
//		const ARCANINE     ; $14
//		const MEW          ; $15
//		const GYARADOS     ; $16
//		const SHELLDER     ; $17
//		const TENTACOOL    ; $18
//		const GASTLY       ; $19
//		const SCYTHER      ; $1A
//		const STARYU       ; $1B
//		const BLASTOISE    ; $1C
//		const PINSIR       ; $1D
//		const TANGELA      ; $1E
//		const MISSINGNO_1F ; $1F
//		const MISSINGNO_20 ; $20
//		const GROWLITHE    ; $21
//		const ONIX         ; $22
//		const FEAROW       ; $23
//		const PIDGEY       ; $24
//		const SLOWPOKE     ; $25
//		const KADABRA      ; $26
//		const GRAVELER     ; $27
//		const CHANSEY      ; $28
//		const MACHOKE      ; $29
//		const MR_MIME      ; $2A
//		const HITMONLEE    ; $2B
//		const HITMONCHAN   ; $2C
//		const ARBOK        ; $2D
//		const PARASECT     ; $2E
//		const PSYDUCK      ; $2F
//		const DROWZEE      ; $30
//		const GOLEM        ; $31
//		const MISSINGNO_32 ; $32
//		const MAGMAR       ; $33
//		const MISSINGNO_34 ; $34
//		const ELECTABUZZ   ; $35
//		const MAGNETON     ; $36
//		const KOFFING      ; $37
//		const MISSINGNO_38 ; $38
//		const MANKEY       ; $39
//		const SEEL         ; $3A
//		const DIGLETT      ; $3B
//		const TAUROS       ; $3C
//		const MISSINGNO_3D ; $3D
//		const MISSINGNO_3E ; $3E
//		const MISSINGNO_3F ; $3F
//		const FARFETCHD    ; $40
//		const VENONAT      ; $41
//		const DRAGONITE    ; $42
//		const MISSINGNO_43 ; $43
//		const MISSINGNO_44 ; $44
//		const MISSINGNO_45 ; $45
//		const DODUO        ; $46
//		const POLIWAG      ; $47
//		const JYNX         ; $48
//		const MOLTRES      ; $49
//		const ARTICUNO     ; $4A
//		const ZAPDOS       ; $4B
//		const DITTO        ; $4C
//		const MEOWTH       ; $4D
//		const KRABBY       ; $4E
//		const MISSINGNO_4F ; $4F
//		const MISSINGNO_50 ; $50
//		const MISSINGNO_51 ; $51
//		const VULPIX       ; $52
//		const NINETALES    ; $53
//		const PIKACHU      ; $54
//		const RAICHU       ; $55
//		const MISSINGNO_56 ; $56
//		const MISSINGNO_57 ; $57
//		const DRATINI      ; $58
//		const DRAGONAIR    ; $59
//		const KABUTO       ; $5A
//		const KABUTOPS     ; $5B
//		const HORSEA       ; $5C
//		const SEADRA       ; $5D
//		const MISSINGNO_5E ; $5E
//		const MISSINGNO_5F ; $5F
//		const SANDSHREW    ; $60
//		const SANDSLASH    ; $61
//		const OMANYTE      ; $62
//		const OMASTAR      ; $63
//		const JIGGLYPUFF   ; $64
//		const WIGGLYTUFF   ; $65
//		const EEVEE        ; $66
//		const FLAREON      ; $67
//		const JOLTEON      ; $68
//		const VAPOREON     ; $69
//		const MACHOP       ; $6A
//		const ZUBAT        ; $6B
//		const EKANS        ; $6C
//		const PARAS        ; $6D
//		const POLIWHIRL    ; $6E
//		const POLIWRATH    ; $6F
//		const WEEDLE       ; $70
//		const KAKUNA       ; $71
//		const BEEDRILL     ; $72
//		const MISSINGNO_73 ; $73
//		const DODRIO       ; $74
//		const PRIMEAPE     ; $75
//		const DUGTRIO      ; $76
//		const VENOMOTH     ; $77
//		const DEWGONG      ; $78
//		const MISSINGNO_79 ; $79
//		const MISSINGNO_7A ; $7A
//		const CATERPIE     ; $7B
//		const METAPOD      ; $7C
//		const BUTTERFREE   ; $7D
//		const MACHAMP      ; $7E
//		const MISSINGNO_7F ; $7F
//		const GOLDUCK      ; $80
//		const HYPNO        ; $81
//		const GOLBAT       ; $82
//		const MEWTWO       ; $83
//		const SNORLAX      ; $84
//		const MAGIKARP     ; $85
//		const MISSINGNO_86 ; $86
//		const MISSINGNO_87 ; $87
//		const MUK          ; $88
//		const MISSINGNO_8A ; $8A
//		const KINGLER      ; $8A
//		const CLOYSTER     ; $8B
//		const MISSINGNO_8C ; $8C
//		const ELECTRODE    ; $8D
//		const CLEFABLE     ; $8E
//		const WEEZING      ; $8F
//		const PERSIAN      ; $90
//		const MAROWAK      ; $91
//		const MISSINGNO_92 ; $92
//		const HAUNTER      ; $93
//		const ABRA         ; $94
//		const ALAKAZAM     ; $95
//		const PIDGEOTTO    ; $96
//		const PIDGEOT      ; $97
//		const STARMIE      ; $98
//		const BULBASAUR    ; $99
//		const VENUSAUR     ; $9A
//		const TENTACRUEL   ; $9B
//		const MISSINGNO_9C ; $9C
//		const GOLDEEN      ; $9D
//		const SEAKING      ; $9E
//		const MISSINGNO_9F ; $9F
//		const MISSINGNO_A0 ; $A0
//		const MISSINGNO_A1 ; $A1
//		const MISSINGNO_A2 ; $A2
//		const PONYTA       ; $A3
//		const RAPIDASH     ; $A4
//		const RATTATA      ; $A5
//		const RATICATE     ; $A6
//		const NIDORINO     ; $A7
//		const NIDORINA     ; $A8
//		const GEODUDE      ; $A9
//		const PORYGON      ; $AA
//		const AERODACTYL   ; $AB
//		const MISSINGNO_AC ; $AC
//		const MAGNEMITE    ; $AD
//		const MISSINGNO_AE ; $AE
//		const MISSINGNO_AF ; $AF
//		const CHARMANDER   ; $B0
//		const SQUIRTLE     ; $B1
//		const CHARMELEON   ; $B2
//		const WARTORTLE    ; $B3
//		const CHARIZARD    ; $B4
//		const MISSINGNO_B5 ; $B5
//		const FOSSIL_KABUTOPS   ; $B6
//		const FOSSIL_AERODACTYL ; $B7
//		const MON_GHOST    ; $B8
//		const ODDISH       ; $B9
//		const GLOOM        ; $BA
//		const VILEPLUME    ; $BB
//		const BELLSPROUT   ; $BC
//		const WEEPINBELL   ; $BD
//		const VICTREEBEL   ; $BE

		//status indexes
		//NONVOLATILE
//		NOSTATUS EQU 0
//		SLP EQU %111 ; sleep counter
//		PSN EQU 3
//		BRN EQU 4
//		FRZ EQU 5
//		PAR EQU 6
		//VOLATILE 1
//		StoringEnergy          EQU 0 ; Bide
//		ThrashingAbout         EQU 1 ; e.g. Thrash
//		AttackingMultipleTimes EQU 2 ; e.g. Double Kick, Fury Attack
//		Flinched               EQU 3
//		ChargingUp             EQU 4 ; e.g. Solar Beam, Fly
//		UsingTrappingMove      EQU 5 ; e.g. Wrap
//		Invulnerable           EQU 6 ; charging up Fly/Dig
//		Confused               EQU 7
		//VOLATILE 2
//		UsingXAccuracy    EQU 0
//		ProtectedByMist   EQU 1
//		GettingPumped     EQU 2 ; Focus Energy
//		;                 EQU 3 ; unused?
//		HasSubstituteUp   EQU 4
//		NeedsToRecharge   EQU 5 ; Hyper Beam
//		UsingRage         EQU 6
//		Seeded            EQU 7
		//VOLATILE 3
//		BadlyPoisoned    EQU 0
//		HasLightScreenUp EQU 1
//		HasReflectUp     EQU 2
//		Transformed      EQU 3
//





		/// <summary>
		/// Compare the specified first and second.
		/// </summary>
		/// <param name="first">First.</param>
		/// <param name="second">Second.</param>
	
		public static void CheckIsGhostBattle(){
			if (wEnemyMonSpecies == 184) { // if its a ghost...
				IsGhostBattle = true;
			}else{
				IsGhostBattle = false;

		}
	}

}
}
