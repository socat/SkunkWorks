﻿// <copyright file="LoremStringTable.cs" company="Microsoft Corporation">
// Copyright (c) 2011 All Rights Reserved
// </copyright>
// <author>v-nicarl</author>
// <email></email>
// <date>17-Jan-11 09:16:30</date>
// <summary></summary>
namespace HelperLibrary.Lipsum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    public partial class Lorem
    {
        #region Fields

        /// <summary>
        /// Nagyon fáj - József Attila
        /// </summary>
        /// <remarks>This text is under public domain</remarks>
        static readonly string Attila = @"
        kivül belõl
        leselkedõ halál elõl
        mint lukba megriadt egérke

        amíg hevülsz
        az asszonyhoz úgy menekülsz
        hogy óvjon karja öle térde

        nemcsak a lágy
        meleg öl csal nemcsak a vágy
        de odataszít a muszáj is

        ezért ölel
        minden ami asszonyra lel
        míg el nem fehérül a száj is

        kettõs teher
        s kettõs kincs hogy szeretni kell
        ki szeret s párra nem találhat

        oly hontalan
        mint amilyen gyámoltalan
        a szükségét végzõ vadállat

        nincsen egyéb
        menedékünk a kés hegyét
        bár anyádnak szegezd te bátor

        és lásd akadt
        nõ ki érti e szavakat
        de mégis ellökött magától

        nincsen helyem
        így élõk közt zúg a fejem
        gondom s fájdalmam kicifrázva

        mint a gyerek
        kezében a csörgõ csereg
        ha magára hagyottan rázza

        mit kellene
        tenni érte és ellene
        nem szégyellem ha kitalálom

        hisz kitaszít
        a világ így is olyat akit
        kábít a nap rettent az álom

        a kultúra
        úgy hull le rólam mint ruha
        másról a boldog szerelemben

        de az hol áll
        hogy nézze mint dobál halál
        s még egyedül kelljen szenvednem

        a csecsemõ
        is szenvedi ha szül a nõ
        páros kínt enyhíthet alázat

        de énnekem
        pénzt hoz fájdalmas énekem
        s hozzám szegõdik a gyalázat

        segítsetek
        ti kisfiúk a szemetek
        pattanjon meg ott õ ahol jár

        ártatlanok
        csizmák alatt sikongjatok
        és mondjátok neki¨nagyon fáj

        ti hû ebek
        kerék alá kerüljetek
        s ugassátok neki nagyon fáj

        nõk terhetek
        viselõk elvetéljetek
        és sírjátok neki nagyon fáj

        ép emberek
        bukjatok öszetörjetek
        s motyogjatok neki nagyon fáj

        ti férfiak
        egymást megtépve nõ miatt
        ne hallgassátok el nagyon fáj

        lovak bikák
        kiket hogy húzzatok igát
        herélnek ríjjátok nagyon fáj

        néma halak
        horgot kapjatok jég alatt
        és tátogjatok rá nagyon fáj

        elevenek
        minden mi kíntól megremeg
        égjen hol laktok kert vadon táj

        s ágya körül
        üszkösen ha elszenderül
        vakogjatok velem nagyon fáj

        hallja míg él
        azt tagadta meg amit ér
        elvonta puszta kénye végett

        kivül belõl
        menekülõ élõ elõl
        a legutolsó menedéket";

        /// <summary>
        /// Le Bateau Ivre - Arthur Baudelaire
        /// </summary>
        /// <remarks>This text is under public domain</remarks>
        static readonly string Baudelaire = @"
        comme je descendais des fleuves impassibles
        je ne me sentis plus guidé par les haleurs
        des peaux-rouges criards les avaient pris pour cibles
        les ayant cloués nus aux poteaux de couleurs

        j'étais insoucieux de tous les équipages
        porteur de blés flamands ou de cotons anglais
        quand avec mes haleurs ont fini ces tapages
        les fleuves m'ont laissé descendre ou je voulais

        dans les clapotements furieux des marées
        moi l'autre hiver plus sourd que les cerveaux d'enfants
        je courus  et les péninsules démarrées
        n'ont pas subi tohu-bohus plus triomphants

        la tempete a béni mes éveils maritimes
        plus léger qu'un bouchon j'ai dansé sur les flots
        qu'on appelle rouleurs éternels de victimes
        dix nuits sans regretter l'oeil niais des falots

        plus douce qu'aux enfants la chair des pommes sures
        l'eau verte pénétra ma coque de sapin
        et des taches de vins bleus et des vomissures
        me lava dispersant gouvernail et grappin

        et des lors je me suis baigné dans le poeme
        de la mer infusé d'astres et lactescent
        dévorant les azurs verts  ou flottaison bleme
        et ravie un noyé pensif parfois descend

        ou teignant tout a coup les bleuités délires
        et rythmes lents sous les rutilements du jour
        plus fortes que l'alcool plus vastes que nos lyres
        fermentent les rousseurs ameres de l'amour

        je sais les cieux crevant en éclairs et les trombes
        et les ressacs et les courants  je sais le soir
        l'aube exaltée ainsi qu'un peuple de colombes
        et j'ai vu quelque fois ce que l'homme a cru voir

        j'ai vu le soleil bas taché d'horreurs mystiques
        illuminant de longs figements violets
        pareils a des acteurs de drames tres-antiques
        les flots roulant au loin leurs frissons de volets

        j'ai revé la nuit verte aux neiges éblouies
        baiser montant aux yeux des mers avec lenteurs
        la circulation des seves inouies
        et l'éveil jaune et bleu des phosphores chanteurs

        j'ai suivi des mois pleins pareille aux vacheries
        hystériques la houle a l'assaut des récifs
        sans songer que les pieds lumineux des maries
        pussent forcer le mufle aux océans poussifs

        j'ai heurté savez-vous d'incroyables florides
        melant aux fleurs des yeux de pantheres a peaux
        d'hommes  des arcs-en-ciel tendus comme des brides
        sous l'horizon des mers a de glauques troupeaux

        j'ai vu fermenter les marais énormes nasses
        ou pourrit dans les joncs tout un léviathan
        des écroulement d'eau au milieu des bonaces
        et les lointains vers les gouffres cataractant

        glaciers soleils d'argent flots nacreux cieux de braises
        échouages hideux au fond des golfes bruns
        ou les serpents géants dévorés de punaises
        choient des arbres tordus avec de noirs parfums

        j'aurais voulu montrer aux enfants ces dorades
        du flot bleu ces poissons d'or ces poissons chantants
        - des écumes de fleurs ont bercé mes dérades
        et d'ineffables vents m'ont ailé par instants

        parfois martyr lassé des pôles et des zones
        la mer dont le sanglot faisait mon roulis doux
        montait vers moi ses fleurs d'ombres aux ventouses jaunes
        et je restais ainsi qu'une femme a genoux

        presque île balottant sur mes bords les querelles
        et les fientes d'oiseaux clabaudeurs aux yeux blonds
        et je voguais lorsqu'a travers mes liens freles
        des noyés descendaient dormir a reculons

        or moi bateau perdu sous les cheveux des anses
        jeté par l'ouragan dans l'éther sans oiseau
        moi dont les monitors et les voiliers des hanses
        n'auraient pas repeché la carcasse ivre d'eau

        libre fumant monté de brumes violettes
        moi qui trouais le ciel rougeoyant comme un mur
        qui porte confiture exquise aux bons poetes
        des lichens de soleil et des morves d'azur

        qui courais taché de lunules électriques
        planche folle escorté des hippocampes noirs
        quand les juillets faisaient crouler a coups de triques
        les cieux ultramarins aux ardents entonnoirs

        moi qui tremblais sentant geindre a cinquante lieues
        le rut des béhémots et les maelstroms épais
        fileur éternel des immobilités bleues
        je regrette l'europe aux anciens parapets

        j'ai vu des archipels sidéraux  et des îles
        dont les cieux délirants sont ouverts au vogueur
        - est-ce en ces nuits sans fond que tu dors et t'exiles
        million d'oiseaux d'or ô future vigueur  -

        mais vrai j'ai trop pleuré  les aubes sont navrantes
        toute lune est atroce et tout soleil amer
        l'âcre amour m'a gonflé de torpeurs enivrantes
        ô que ma quille éclate  ô que j'aille a la mer

        si je désire une eau d'europe c'est la flache
        noire et froide ou vers le crépuscule embaumé
        un enfant accroupi plein de tristesses lâche
        un bateau frele comme un papillon de mai

        je ne puis plus baigné de vos langueurs ô lames
        enlever leur sillage aux porteurs de cotons
        ni traverser l'orgueil des drapeaux et des flammes
        ni nager sous les yeux horribles des pontons";

        /// <summary>
        /// Lorem ipsum - Cicero
        /// </summary>
        /// <remarks>This text is under public domain</remarks>
        static readonly string Cicero = @"
        lorem ipsum dolor sit amet consetetur sadipscing elitr sed diam nonumy
        eirmod tempor invidunt ut labore et dolore magna aliquyam erat sed diam
        voluptua at vero eos et accusam et justo duo dolores et ea rebum stet clita
        kasd gubergren no sea takimata sanctus est lorem ipsum dolor sit amet lorem
        ipsum dolor sit amet consetetur sadipscing elitr sed diam nonumy eirmod
        tempor invidunt ut labore et dolore magna aliquyam erat sed diam voluptua at
        vero eos et accusam et justo duo dolores et ea rebum stet clita kasd
        gubergren no sea takimata sanctus est lorem ipsum dolor sit amet lorem ipsum
        dolor sit amet consetetur sadipscing elitr sed diam nonumy eirmod tempor
        invidunt ut labore et dolore magna aliquyam erat sed diam voluptua at vero
        eos et accusam et justo duo dolores et ea rebum stet clita kasd gubergren no
        sea takimata sanctus est lorem ipsum dolor sit amet

        duis autem vel eum iriure dolor in hendrerit in vulputate velit esse
        molestie consequat vel illum dolore eu feugiat nulla facilisis at vero eros
        et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril
        delenit augue duis dolore te feugait nulla facilisi lorem ipsum dolor sit
        amet consectetuer adipiscing elit sed diam nonummy nibh euismod tincidunt ut
        laoreet dolore magna aliquam erat volutpat

        ut wisi enim ad minim veniam quis nostrud exerci tation ullamcorper suscipit
        lobortis nisl ut aliquip ex ea commodo consequat duis autem vel eum iriure
        dolor in hendrerit in vulputate velit esse molestie consequat vel illum
        dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio
        dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te
        feugait nulla facilisi

        nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet
        doming id quod mazim placerat facer possim assum lorem ipsum dolor sit amet
        consectetuer adipiscing elit sed diam nonummy nibh euismod tincidunt ut
        laoreet dolore magna aliquam erat volutpat ut wisi enim ad minim veniam quis
        nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea
        commodo consequat

        duis autem vel eum iriure dolor in hendrerit in vulputate velit esse
        molestie consequat vel illum dolore eu feugiat nulla facilisis

        at vero eos et accusam et justo duo dolores et ea rebum stet clita kasd
        gubergren no sea takimata sanctus est lorem ipsum dolor sit amet lorem ipsum
        dolor sit amet consetetur sadipscing elitr sed diam nonumy eirmod tempor
        invidunt ut labore et dolore magna aliquyam erat sed diam voluptua at vero
        eos et accusam et justo duo dolores et ea rebum stet clita kasd gubergren no
        sea takimata sanctus est lorem ipsum dolor sit amet lorem ipsum dolor sit
        amet consetetur sadipscing elitr at accusam aliquyam diam diam dolore
        dolores duo eirmod eos erat et nonumy sed tempor et et invidunt justo labore
        stet clita ea et gubergren kasd magna no rebum sanctus sea sed takimata ut
        vero voluptua est lorem ipsum dolor sit amet lorem ipsum dolor sit amet
        consetetur sadipscing elitr sed diam nonumy eirmod tempor invidunt ut labore
        et dolore magna aliquyam erat

        consetetur sadipscing elitr sed diam nonumy eirmod tempor invidunt ut labore
        et dolore magna aliquyam erat sed diam voluptua at vero eos et accusam et
        justo duo dolores et ea rebum stet clita kasd gubergren no sea takimata
        sanctus est lorem ipsum dolor sit amet lorem ipsum dolor sit amet consetetur
        sadipscing elitr sed diam nonumy eirmod tempor invidunt ut labore et dolore
        magna aliquyam erat sed diam voluptua at vero eos et accusam et justo duo
        dolores et ea rebum stet clita kasd gubergren no sea takimata sanctus est
        lorem ipsum dolor sit amet lorem ipsum dolor sit amet consetetur sadipscing
        elitr sed diam nonumy eirmod tempor invidunt ut labore et dolore magna
        aliquyam erat sed diam voluptua at vero eos et accusam et justo duo dolores
        et ea rebum stet clita kasd gubergren no sea takimata sanctus est lorem
        ipsum dolor sit amet";

        /// <summary>
        /// Faust: Der Tragödie erster Teil - Johann Wolfgang von Goethe
        /// </summary>
        /// <remarks>This text is under public domain</remarks>
        static readonly string Faust = @"
        ihr naht euch wieder schwankende gestalten
        die früh sich einst dem trüben blick gezeigt
        versuch ich wohl euch diesmal festzuhalten
        fühl ich mein herz noch jenem wahn geneigt
        ihr drängt euch zu  nun gut so mögt ihr walten
        wie ihr aus dunst und nebel um mich steigt
        mein busen fühlt sich jugendlich erschüttert
        vom zauberhauch der euren zug umwittert

        ihr bringt mit euch die bilder froher tage
        und manche liebe schatten steigen auf
        gleich einer alten halbverklungnen sage
        kommt erste lieb und freundschaft mit herauf
        der schmerz wird neu es wiederholt die klage
        des lebens labyrinthisch irren lauf
        und nennt die guten die um schöne stunden
        vom glück getäuscht vor mir hinweggeschwunden

        sie hören nicht die folgenden gesänge
        die seelen denen ich die ersten sang
        zerstoben ist das freundliche gedränge
        verklungen ach  der erste widerklang
        mein lied ertönt der unbekannten menge
        ihr beifall selbst macht meinem herzen bang
        und was sich sonst an meinem lied erfreuet
        wenn es noch lebt irrt in der welt zerstreuet

        und mich ergreift ein längst entwöhntes sehnen
        nach jenem stillen ernsten geisterreich
        es schwebet nun in unbestimmten tönen
        mein lispelnd lied der äolsharfe gleich
        ein schauer faßt mich träne folgt den tränen
        das strenge herz es fühlt sich mild und weich
        was ich besitze seh ich wie im weiten
        und was verschwand wird mir zu wirklichkeiten";

        /// <summary>
        /// In der Fremde - Heinrich Heine
        /// </summary>
        /// <remarks>This text is under public domain</remarks>
        static readonly string Fremde = @"
        es treibt dich fort von ort zu ort
        du weißt nicht mal warum
        im winde klingt ein sanftes wort
        schaust dich verwundert um

        die liebe die dahinten blieb
        sie ruft dich sanft zurück
        o komm zurück ich hab dich lieb
        du bist mein einz'ges glück

        doch weiter weiter sonder rast
        du darfst nicht stillestehn
        was du so sehr geliebet hast
        sollst du nicht wiedersehn

        du bist ja heut so grambefangen
        wie ich dich lange nicht geschaut
        es perlet still von deinen wangen
        und deine seufzer werden laue

        denkst du der heimat die so ferne
        so nebelferne dir verschwand
        gestehe mir's du wärest gerne
        manchmal im teuren vaterland

        denkst du der dame die so niedlich
        mit kleinem zürnen dich ergötzt
        oft zürntest du dann ward sie friedlich
        und immer lachtet ihr zuletzt

        denkst du der freunde die da sanken
        an deine brust in großer stund'
        im herzen stürmten die gedanken
        jedoch verschwiegen blieb der mund

        denkst du der mutter und der schwester
        mit beiden standest du ja gut
        ich glaube gar es schmilzt mein bester
        in deiner brust der wilde mut

        denkst du der vögel und der bäume
        des schönen gartens wo du oft
        geträumt der liebe junge träume
        wo du gezagt wo du gehofft

        es ist schon spät die nacht ist helle
        trübhell gefärbt vom feuchten schnee
        ankleiden muß ich mich nun schnelle
        und in gesellschaft gehn o weh";

        /// <summary>
        /// La Divina Commedia di Dante: Inferno, Cantos I & II - Dante Alighieri
        /// </summary>
        /// <remarks>This text is under public domain</remarks>
        static readonly string Inferno = @"
        Nel mezzo del cammin di nostra vita mi ritrovai per una selva oscura, ché la diritta via era smarrita.
        Ahi quanto a dir qual era è cosa dura esta selva selvaggia e aspra e forte che nel pensier rinova la paura!
        Tant’ è amara che poco è più morte; ma per trattar del ben ch’i’ vi trovai, dirò de l’altre cose ch’i’ v’ho scorte.
        Io non so ben ridir com’ i’ v’intrai, tant’ era pien di sonno a quel punto che la verace via abbandonai.
        Ma poi ch’i’ fui al piè d’un colle giunto, là dove terminava quella valle che m’avea di paura il cor compunto,
        guardai in alto e vidi le sue spalle vestite già de’ raggi del pianeta che mena dritto altrui per ogne calle.
        Allor fu la paura un poco queta, che nel lago del cor m’era durata la notte ch’i’ passai con tanta pieta.
        E come quei che con lena affannata, uscito fuor del pelago a la riva, si volge a l’acqua perigliosa e guata,
        così l’animo mio, ch’ancor fuggiva, si volse a retro a rimirar lo passo che non lasciò già mai persona viva.
        Poi ch’èi posato un poco il corpo lasso, ripresi via per la piaggia diserta, sì che ’l piè fermo sempre era ’l più basso.
        Ed ecco, quasi al cominciar de l’erta, una lonza leggera e presta molto, che di pel macolato era coverta;
        e non mi si partia dinanzi al volto, anzi ’mpediva tanto il mio cammino, ch’i’ fui per ritornar più volte vòlto.
        Temp’ era dal principio del mattino, e ’l sol montava ’n sù con quelle stelle ch’eran con lui quando l’amor divino
        mosse di prima quelle cose belle; sì ch’a bene sperar m’era cagione di quella fiera a la gaetta pelle
        l’ora del tempo e la dolce stagione; ma non sì che paura non mi desse la vista che m’apparve d’un leone.
        Questi parea che contra me venisse con la test’ alta e con rabbiosa fame, sì che parea che l’aere ne tremesse.
        Ed una lupa, che di tutte brame sembiava carca ne la sua magrezza, e molte genti fé già viver grame,
        questa mi porse tanto di gravezza con la paura ch’uscia di sua vista, ch’io perdei la speranza de l’altezza.
        E qual è quei che volontieri acquista, e giugne ’l tempo che perder lo face, che ’n tutti suoi pensier piange e s’attrista;
        tal mi fece la bestia sanza pace, che, venendomi ’ncontro, a poco a poco mi ripigneva là dove ’l sol tace.
        Mentre ch’i’ rovinava in basso loco, dinanzi a li occhi mi si fu offerto chi per lungo silenzio parea fioco.
        Quando vidi costui nel gran diserto, Miserere di me, gridai a lui, qual che tu sii, od ombra od omo certo!.
        Rispuosemi: Non omo, omo già fui, e li parenti miei furon lombardi, mantoani per patrïa ambedui.
        Nacqui sub Iulio, ancor che fosse tardi, e vissi a Roma sotto ’l buono Augusto nel tempo de li dèi falsi e bugiardi.
        Poeta fui, e cantai di quel giusto figliuol d’Anchise che venne di Troia, poi che ’l superbo Ilïón fu combusto.
        Ma tu perché ritorni a tanta noia? perché non sali il dilettoso monte ch’è principio e cagion di tutta gioia?.
        Or se’ tu quel Virgilio e quella fonte che spandi di parlar sì largo fiume?, rispuos’ io lui con vergognosa fronte.
        O de li altri poeti onore e lume, vagliami ’l lungo studio e ’l grande amore che m’ha fatto cercar lo tuo volume.
        Tu se’ lo mio maestro e ’l mio autore, tu se’ solo colui da cu’ io tolsi lo bello stilo che m’ha fatto onore.
        Vedi la bestia per cu’ io mi volsi; aiutami da lei, famoso saggio, ch’ella mi fa tremar le vene e i polsi.
        A te convien tenere altro vïaggio, rispuose, poi che lagrimar mi vide, se vuo’ campar d’esto loco selvaggio;
        ché questa bestia, per la qual tu gride, non lascia altrui passar per la sua via, ma tanto lo ’mpedisce che l’uccide;
        e ha natura sì malvagia e ria, che mai non empie la bramosa voglia, e dopo ’l pasto ha più fame che pria.
        Molti son li animali a cui s’ammoglia, e più saranno ancora, infin che ’l veltro verrà, che la farà morir con doglia.
        Questi non ciberà terra né peltro, ma sapïenza, amore e virtute, e sua nazion sarà tra feltro e feltro.
        Di quella umile Italia fia salute per cui morì la vergine Cammilla, Eurialo e Turno e Niso di ferute.
        Questi la caccerà per ogne villa, fin che l’avrà rimessa ne lo ’nferno, là onde ’nvidia prima dipartilla.
        Ond’ io per lo tuo me’ penso e discerno che tu mi segui, e io sarò tua guida, e trarrotti di qui per loco etterno;
        ove udirai le disperate strida, vedrai li antichi spiriti dolenti, ch’a la seconda morte ciascun grida;
        e vederai color che son contenti nel foco, perché speran di venire quando che sia a le beate genti.
        A le quai poi se tu vorrai salire, anima fia a ciò più di me degna: con lei ti lascerò nel mio partire;
        ché quello imperador che là sù regna, perch’ i’ fu’ ribellante a la sua legge, non vuol che ’n sua città per me si vegna.
        In tutte parti impera e quivi regge; quivi è la sua città e l’alto seggio: oh felice colui cu’ ivi elegge!.
        E io a lui: Poeta, io ti richeggio per quello Dio che tu non conoscesti, acciò ch’io fugga questo male e peggio,
        che tu mi meni là dov’ or dicesti, sì ch’io veggia la porta di san Pietro e color cui tu fai cotanto mesti.
        Allor si mosse, e io li tenni dietro.
        Lo giorno se n’andava, e l’aere bruno toglieva li animai che sono in terra da le fatiche loro; e io sol uno
        m’apparecchiava a sostener la guerra sì del cammino e sì de la pietate, che ritrarrà la mente che non erra.
        O muse, o alto ingegno, or m’aiutate; o mente che scrivesti ciò ch’io vidi, qui si parrà la tua nobilitate.
        Io cominciai: Poeta che mi guidi, guarda la mia virtù s’ell’ è possente, prima ch’a l’alto passo tu mi fidi.
        Tu dici che di Silvïo il parente, corruttibile ancora, ad immortale secolo andò, e fu sensibilmente.
        Però, se l’avversario d’ogne male cortese i fu, pensando l’alto effetto ch’uscir dovea di lui, e ’l chi e ’l quale
        non pare indegno ad omo d’intelletto; ch’e’ fu de l’alma Roma e di suo impero ne l’empireo ciel per padre eletto:
        la quale e ’l quale, a voler dir lo vero, fu stabilita per lo loco santo u’ siede il successor del maggior Piero.
        Per quest’ andata onde li dai tu vanto, intese cose che furon cagione di sua vittoria e del papale ammanto.
        Andovvi poi lo Vas d’elezïone, per recarne conforto a quella fede ch’è principio a la via di salvazione.
        Ma io, perché venirvi? o chi ’l concede? Io non Enëa, io non Paulo sono; me degno a ciò né io né altri ’l crede.
        Per che, se del venire io m’abbandono, temo che la venuta non sia folle. Se’ savio; intendi me’ ch’i’ non ragiono.
        E qual è quei che disvuol ciò che volle e per novi pensier cangia proposta, sì che dal cominciar tutto si tolle,
        tal mi fec’ ïo ’n quella oscura costa, perché, pensando, consumai la ’mpresa che fu nel cominciar cotanto tosta.
        S’i’ ho ben la parola tua intesa, rispuose del magnanimo quell’ ombra, l’anima tua è da viltade offesa;
        la qual molte fïate l’omo ingombra sì che d’onrata impresa lo rivolve, come falso veder bestia quand’ ombra.
        Da questa tema acciò che tu ti solve, dirotti perch’ io venni e quel ch’io ’ntesi nel primo punto che di te mi dolve.
        Io era tra color che son sospesi, e donna mi chiamò beata e bella, tal che di comandare io la richiesi.
        Lucevan li occhi suoi più che la stella; e cominciommi a dir soave e piana, con angelica voce, in sua favella:
        “O anima cortese mantoana, di cui la fama ancor nel mondo dura, e durerà quanto ’l mondo lontana,
        l’amico mio, e non de la ventura, ne la diserta piaggia è impedito sì nel cammin, che vòlt’ è per paura;
        e temo che non sia già sì smarrito, ch’io mi sia tardi al soccorso levata, per quel ch’i’ ho di lui nel cielo udito.
        Or movi, e con la tua parola ornata e con ciò c’ha mestieri al suo campare, l’aiuta sì ch’i’ ne sia consolata.
        I’ son Beatrice che ti faccio andare; vegno del loco ove tornar disio; amor mi mosse, che mi fa parlare.
        Quando sarò dinanzi al segnor mio, di te mi loderò sovente a lui”. Tacette allora, e poi comincia’ io:
        “O donna di virtù sola per cui l’umana spezie eccede ogne contento di quel ciel c’ha minor li cerchi sui,
        tanto m’aggrada il tuo comandamento, che l’ubidir, se già fosse, m’è tardi; più non t’è uo’ ch’aprirmi il tuo talento.
        Ma dimmi la cagion che non ti guardi de lo scender qua giuso in questo centro de l’ampio loco ove tornar tu ardi”.
        “Da che tu vuo’ saver cotanto a dentro, dirotti brievemente”, mi rispuose, “perch’ i’ non temo di venir qua entro.
        Temer si dee di sole quelle cose c’hanno potenza di fare altrui male; de l’altre no, ché non son paurose.
        I’ son fatta da Dio, sua mercé, tale, che la vostra miseria non mi tange, né fiamma d’esto ’ncendio non m’assale.
        Donna è gentil nel ciel che si compiange di questo ’mpedimento ov’ io ti mando, sì che duro giudicio là sù frange.
        Questa chiese Lucia in suo dimando e disse:—Or ha bisogno il tuo fedele di te, e io a te lo raccomando—.
        Lucia, nimica di ciascun crudele, si mosse, e venne al loco dov’ i’ era, che mi sedea con l’antica Rachele.
        Disse:—Beatrice, loda di Dio vera, ché non soccorri quei che t’amò tanto, ch’uscì per te de la volgare schiera?
        Non odi tu la pieta del suo pianto, non vedi tu la morte che ’l combatte su la fiumana ove ’l mar non ha vanto?—.
        Al mondo non fur mai persone ratte a far lor pro o a fuggir lor danno, com’ io, dopo cotai parole fatte,
        venni qua giù del mio beato scanno, fidandomi del tuo parlare onesto, ch’onora te e quei ch’udito l’hanno”.
        Poscia che m’ebbe ragionato questo, li occhi lucenti lagrimando volse, per che mi fece del venir più presto.
        E venni a te così com’ ella volse: d’inanzi a quella fiera ti levai che del bel monte il corto andar ti tolse.
        Dunque: che è? perché, perché restai, perché tanta viltà nel core allette, perché ardire e franchezza non hai,
        poscia che tai tre donne benedette curan di te ne la corte del cielo, e ’l mio parlar tanto ben ti promette?.
        Quali fioretti dal notturno gelo chinati e chiusi, poi che ’l sol li ’mbianca, si drizzan tutti aperti in loro stelo,
        tal mi fec’ io di mia virtude stanca, e tanto buono ardire al cor mi corse, ch’i’ cominciai come persona franca:
        Oh pietosa colei che mi soccorse! e te cortese ch’ubidisti tosto a le vere parole che ti porse!
        Tu m’hai con disiderio il cor disposto sì al venir con le parole tue, ch’i’ son tornato nel primo proposto.
        Or va, ch’un sol volere è d’ambedue: tu duca, tu segnore e tu maestro. Così li dissi; e poi che mosso fue,
        intrai per lo cammino alto e silvestro.
        ‘Per me si va ne la città dolente, per me si va ne l’etterno dolore, per me si va tra la perduta gente.
        Giustizia mosse il mio alto fattore; fecemi la divina podestate, la somma sapïenza e ’l primo amore.
        Dinanzi a me non fuor cose create se non etterne, e io etterno duro. Lasciate ogne speranza, voi ch’intrate’.
        Queste parole di colore oscuro vid’ ïo scritte al sommo d’una porta; per ch’io: Maestro, il senso lor m’è duro.
        Ed elli a me, come persona accorta: Qui si convien lasciare ogne sospetto; ogne viltà convien che qui sia morta.
        Noi siam venuti al loco ov’ i’ t’ho detto che tu vedrai le genti dolorose c’hanno perduto il ben de l’intelletto.
        E poi che la sua mano a la mia puose con lieto volto, ond’ io mi confortai, mi mise dentro a le segrete cose.
        Quivi sospiri, pianti e alti guai risonavan per l’aere sanza stelle, per ch’io al cominciar ne lagrimai.
        Diverse lingue, orribili favelle, parole di dolore, accenti d’ira, voci alte e fioche, e suon di man con elle
        facevano un tumulto, il qual s’aggira sempre in quell’ aura sanza tempo tinta, come la rena quando turbo spira.
        E io ch’avea d’error la testa cinta, dissi: Maestro, che è quel ch’i’ odo? e che gent’ è che par nel duol sì vinta?.
        Ed elli a me: Questo misero modo tegnon l’anime triste di coloro che visser sanza ’nfamia e sanza lodo.
        Mischiate sono a quel cattivo coro de li angeli che non furon ribelli né fur fedeli a Dio, ma per sé fuoro.
        Caccianli i ciel per non esser men belli, né lo profondo inferno li riceve, ch’alcuna gloria i rei avrebber d’elli.
        E io: Maestro, che è tanto greve a lor che lamentar li fa sì forte?. Rispuose: Dicerolti molto breve.
        Questi non hanno speranza di morte, e la lor cieca vita è tanto bassa, che ’nvidïosi son d’ogne altra sorte.
        Fama di loro il mondo esser non lassa; misericordia e giustizia li sdegna: non ragioniam di lor, ma guarda e passa.
        E io, che riguardai, vidi una ’nsegna che girando correva tanto ratta, che d’ogne posa mi parea indegna;
        e dietro le venìa sì lunga tratta di gente, ch’i’ non averei creduto che morte tanta n’avesse disfatta.
        Poscia ch’io v’ebbi alcun riconosciuto, vidi e conobbi l’ombra di colui che fece per viltade il gran rifiuto.
        Incontanente intesi e certo fui che questa era la setta d’i cattivi, a Dio spiacenti e a’ nemici sui.
        Questi sciaurati, che mai non fur vivi, erano ignudi e stimolati molto da mosconi e da vespe ch’eran ivi.
        Elle rigavan lor di sangue il volto, che, mischiato di lagrime, a’ lor piedi da fastidiosi vermi era ricolto.
        E poi ch’a riguardar oltre mi diedi, vidi genti a la riva d’un gran fiume; per ch’io dissi: Maestro, or mi concedi
        ch’i’ sappia quali sono, e qual costume le fa di trapassar parer sì pronte, com’ i’ discerno per lo fioco lume.
        Ed elli a me: Le cose ti fier conte quando noi fermerem li nostri passi su la trista riviera d’Acheronte.
        Allor con li occhi vergognosi e bassi, temendo no ’l mio dir li fosse grave, infino al fiume del parlar mi trassi.
        Ed ecco verso noi venir per nave un vecchio, bianco per antico pelo, gridando: Guai a voi, anime prave!
        Non isperate mai veder lo cielo: i’ vegno per menarvi a l’altra riva ne le tenebre etterne, in caldo e ’n gelo.
        E tu che se’ costì, anima viva, pàrtiti da cotesti che son morti. Ma poi che vide ch’io non mi partiva,
        disse: Per altra via, per altri porti verrai a piaggia, non qui, per passare: più lieve legno convien che ti porti.
        E ’l duca lui: Caron, non ti crucciare: vuolsi così colà dove si puote ciò che si vuole, e più non dimandare.
        Quinci fuor quete le lanose gote al nocchier de la livida palude, che ’ntorno a li occhi avea di fiamme rote.
        Ma quell’ anime, ch’eran lasse e nude, cangiar colore e dibattero i denti, ratto che ’nteser le parole crude.
        Bestemmiavano Dio e lor parenti, l’umana spezie e ’l loco e ’l tempo e ’l seme di lor semenza e di lor nascimenti.
        Poi si ritrasser tutte quante insieme, forte piangendo, a la riva malvagia ch’attende ciascun uom che Dio non teme.
        Caron dimonio, con occhi di bragia loro accennando, tutte le raccoglie; batte col remo qualunque s’adagia.
        Come d’autunno si levan le foglie l’una appresso de l’altra, fin che ’l ramo vede a la terra tutte le sue spoglie,
        similemente il mal seme d’Adamo gittansi di quel lito ad una ad una, per cenni come augel per suo richiamo.
        Così sen vanno su per l’onda bruna, e avanti che sien di là discese, anche di qua nuova schiera s’auna.
        Figliuol mio, disse ’l maestro cortese, quelli che muoion ne l’ira di Dio tutti convegnon qui d’ogne paese;
        e pronti sono a trapassar lo rio, ché la divina giustizia li sprona, sì che la tema si volve in disio.
        Quinci non passa mai anima buona; e però, se Caron di te si lagna, ben puoi sapere omai che ’l suo dir suona.
        Finito questo, la buia campagna tremò sì forte, che de lo spavento la mente di sudore ancor mi bagna.
        La terra lagrimosa diede vento, che balenò una luce vermiglia la qual mi vinse ciascun sentimento;
        e caddi come l’uom cui sonno piglia.
        Ruppemi l’alto sonno ne la testa un greve truono, sì ch’io mi riscossi come persona ch’è per forza desta;
        e l’occhio riposato intorno mossi, dritto levato, e fiso riguardai per conoscer lo loco dov’ io fossi.
        Vero è che ’n su la proda mi trovai de la valle d’abisso dolorosa che ’ntrono accoglie d’infiniti guai.
        Oscura e profonda era e nebulosa tanto che, per ficcar lo viso a fondo, io non vi discernea alcuna cosa.
        Or discendiam qua giù nel cieco mondo, cominciò il poeta tutto smorto. Io sarò primo, e tu sarai secondo.
        E io, che del color mi fui accorto, dissi: Come verrò, se tu paventi che suoli al mio dubbiare esser conforto?.
        Ed elli a me: L’angoscia de le genti che son qua giù, nel viso mi dipigne quella pietà che tu per tema senti.
        Andiam, ché la via lunga ne sospigne. Così si mise e così mi fé intrare nel primo cerchio che l’abisso cigne.
        Quivi, secondo che per ascoltare, non avea pianto mai che di sospiri che l’aura etterna facevan tremare;
        ciò avvenia di duol sanza martìri, ch’avean le turbe, ch’eran molte e grandi, d’infanti e di femmine e di viri.
        Lo buon maestro a me: Tu non dimandi che spiriti son questi che tu vedi? Or vo’ che sappi, innanzi che più andi,
        ch’ei non peccaro; e s’elli hanno mercedi, non basta, perché non ebber battesmo, ch’è porta de la fede che tu credi;
        e s’e’ furon dinanzi al cristianesmo, non adorar debitamente a Dio: e di questi cotai son io medesmo.
        Per tai difetti, non per altro rio, semo perduti, e sol di tanto offesi che sanza speme vivemo in disio.
        Gran duol mi prese al cor quando lo ’ntesi, però che gente di molto valore conobbi che ’n quel limbo eran sospesi.
        Dimmi, maestro mio, dimmi, segnore, comincia’ io per voler esser certo di quella fede che vince ogne errore:
        uscicci mai alcuno, o per suo merto o per altrui, che poi fosse beato?. E quei che ’ntese il mio parlar coverto,
        rispuose: Io era nuovo in questo stato, quando ci vidi venire un possente, con segno di vittoria coronato.
        Trasseci l’ombra del primo parente, d’Abèl suo figlio e quella di Noè, di Moïsè legista e ubidente;
        Abraàm patrïarca e Davìd re, Israèl con lo padre e co’ suoi nati e con Rachele, per cui tanto fé,
        e altri molti, e feceli beati. E vo’ che sappi che, dinanzi ad essi, spiriti umani non eran salvati.
        Non lasciavam l’andar perch’ ei dicessi, ma passavam la selva tuttavia, la selva, dico, di spiriti spessi.
        Non era lunga ancor la nostra via di qua dal sonno, quand’ io vidi un foco ch’emisperio di tenebre vincia.
        Di lungi n’eravamo ancora un poco, ma non sì ch’io non discernessi in parte ch’orrevol gente possedea quel loco.
        O tu ch’onori scïenzïa e arte, questi chi son c’hanno cotanta onranza, che dal modo de li altri li diparte?.
        E quelli a me: L’onrata nominanza che di lor suona sù ne la tua vita, grazïa acquista in ciel che sì li avanza.
        Intanto voce fu per me udita: Onorate l’altissimo poeta; l’ombra sua torna, ch’era dipartita.
        Poi che la voce fu restata e queta, vidi quattro grand’ ombre a noi venire: sembianz’ avevan né trista né lieta.
        Lo buon maestro cominciò a dire: Mira colui con quella spada in mano, che vien dinanzi ai tre sì come sire:
        quelli è Omero poeta sovrano; l’altro è Orazio satiro che vene; Ovidio è ’l terzo, e l’ultimo Lucano.
        Però che ciascun meco si convene nel nome che sonò la voce sola, fannomi onore, e di ciò fanno bene.
        Così vid’ i’ adunar la bella scola di quel segnor de l’altissimo canto che sovra li altri com’ aquila vola.
        Da ch’ebber ragionato insieme alquanto, volsersi a me con salutevol cenno, e ’l mio maestro sorrise di tanto;
        e più d’onore ancora assai mi fenno, ch’e’ sì mi fecer de la loro schiera, sì ch’io fui sesto tra cotanto senno.
        Così andammo infino a la lumera, parlando cose che ’l tacere è bello, sì com’ era ’l parlar colà dov’ era.
        Venimmo al piè d’un nobile castello, sette volte cerchiato d’alte mura, difeso intorno d’un bel fiumicello.
        Questo passammo come terra dura; per sette porte intrai con questi savi: giugnemmo in prato di fresca verdura.
        Genti v’eran con occhi tardi e gravi, di grande autorità ne’ lor sembianti: parlavan rado, con voci soavi.
        Traemmoci così da l’un de’ canti, in loco aperto, luminoso e alto, sì che veder si potien tutti quanti.
        Colà diritto, sovra ’l verde smalto, mi fuor mostrati li spiriti magni, che del vedere in me stesso m’essalto.
        I’ vidi Eletra con molti compagni, tra ’ quai conobbi Ettòr ed Enea, Cesare armato con li occhi grifagni.
        Vidi Cammilla e la Pantasilea; da l’altra parte vidi ’l re Latino che con Lavina sua figlia sedea.
        Vidi quel Bruto che cacciò Tarquino, Lucrezia, Iulia, Marzïa e Corniglia; e solo, in parte, vidi ’l Saladino.
        Poi ch’innalzai un poco più le ciglia, vidi ’l maestro di color che sanno seder tra filosofica famiglia.
        Tutti lo miran, tutti onor li fanno: quivi vid’ ïo Socrate e Platone, che ’nnanzi a li altri più presso li stanno;
        Democrito che ’l mondo a caso pone,
        Dïogenès, Anassagora e Tale,
        Empedoclès, Eraclito e Zenone;
        e vidi il buono accoglitor del quale, Dïascoride dico; e vidi Orfeo, Tulïo e Lino e Seneca morale;
        Euclide geomètra e Tolomeo,
        Ipocràte, Avicenna e Galïeno,
        Averoìs, che ’l gran comento feo.
        Io non posso ritrar di tutti a pieno, però che sì mi caccia il lungo tema, che molte volte al fatto il dir vien meno.
        La sesta compagnia in due si scema: per altra via mi mena il savio duca, fuor de la queta, ne l’aura che trema.
        E vegno in parte ove non è che luca.
        Così discesi del cerchio primaio giù nel secondo, che men loco cinghia e tanto più dolor, che punge a guaio.
        Stavvi Minòs orribilmente, e ringhia: essamina le colpe ne l’intrata; giudica e manda secondo ch’avvinghia.
        Dico che quando l’anima mal nata li vien dinanzi, tutta si confessa; e quel conoscitor de le peccata
        vede qual loco d’inferno è da essa; cignesi con la coda tante volte quantunque gradi vuol che giù sia messa.
        Sempre dinanzi a lui ne stanno molte: vanno a vicenda ciascuna al giudizio, dicono e odono e poi son giù volte.
        O tu che vieni al doloroso ospizio, disse Minòs a me quando mi vide, lasciando l’atto di cotanto offizio,
        guarda com’ entri e di cui tu ti fide; non t’inganni l’ampiezza de l’intrare!. E ’l duca mio a lui: Perché pur gride?
        Non impedir lo suo fatale andare: vuolsi così colà dove si puote ciò che si vuole, e più non dimandare.
        Or incomincian le dolenti note a farmisi sentire; or son venuto là dove molto pianto mi percuote.
        Io venni in loco d’ogne luce muto, che mugghia come fa mar per tempesta, se da contrari venti è combattuto.
        La bufera infernal, che mai non resta, mena li spirti con la sua rapina; voltando e percotendo li molesta.
        Quando giungon davanti a la ruina, quivi le strida, il compianto, il lamento; bestemmian quivi la virtù divina.
        Intesi ch’a così fatto tormento enno dannati i peccator carnali, che la ragion sommettono al talento.
        E come li stornei ne portan l’ali nel freddo tempo, a schiera larga e piena, così quel fiato li spiriti mali
        di qua, di là, di giù, di sù li mena; nulla speranza li conforta mai, non che di posa, ma di minor pena.
        E come i gru van cantando lor lai, faccendo in aere di sé lunga riga, così vid’ io venir, traendo guai,
        ombre portate da la detta briga; per ch’i’ dissi: Maestro, chi son quelle genti che l’aura nera sì gastiga?.
        La prima di color di cui novelle tu vuo’ saper, mi disse quelli allotta, fu imperadrice di molte favelle.
        A vizio di lussuria fu sì rotta, che libito fé licito in sua legge, per tòrre il biasmo in che era condotta.
        Ell’ è Semiramìs, di cui si legge che succedette a Nino e fu sua sposa: tenne la terra che ’l Soldan corregge.
        L’altra è colei che s’ancise amorosa, e ruppe fede al cener di Sicheo; poi è Cleopatràs lussurïosa.
        Elena vedi, per cui tanto reo tempo si volse, e vedi ’l grande Achille, che con amore al fine combatteo.
        Vedi Parìs, Tristano; e più di mille ombre mostrommi e nominommi a dito, ch’amor di nostra vita dipartille.
        Poscia ch’io ebbi ’l mio dottore udito nomar le donne antiche e ’ cavalieri, pietà mi giunse, e fui quasi smarrito.
        I’ cominciai: Poeta, volontieri parlerei a quei due che ’nsieme vanno, e paion sì al vento esser leggeri.
        Ed elli a me: Vedrai quando saranno più presso a noi; e tu allor li priega per quello amor che i mena, ed ei verranno.
        Sì tosto come il vento a noi li piega, mossi la voce: O anime affannate, venite a noi parlar, s’altri nol niega!.
        Quali colombe dal disio chiamate con l’ali alzate e ferme al dolce nido vegnon per l’aere, dal voler portate;
        cotali uscir de la schiera ov’ è Dido, a noi venendo per l’aere maligno, sì forte fu l’affettüoso grido.
        O animal grazïoso e benigno che visitando vai per l’aere perso noi che tignemmo il mondo di sanguigno,
        se fosse amico il re de l’universo, noi pregheremmo lui de la tua pace, poi c’hai pietà del nostro mal perverso.
        Di quel che udire e che parlar vi piace, noi udiremo e parleremo a voi, mentre che ’l vento, come fa, ci tace.
        Siede la terra dove nata fui su la marina dove ’l Po discende per aver pace co’ seguaci sui.
        Amor, ch’al cor gentil ratto s’apprende, prese costui de la bella persona che mi fu tolta; e ’l modo ancor m’offende.
        Amor, ch’a nullo amato amar perdona, mi prese del costui piacer sì forte, che, come vedi, ancor non m’abbandona.
        Amor condusse noi ad una morte.
        Caina attende chi a vita ci spense.
        Queste parole da lor ci fuor porte.
        Quand’ io intesi quell’ anime offense, china’ il viso, e tanto il tenni basso, fin che ’l poeta mi disse: Che pense?.
        Quando rispuosi, cominciai: Oh lasso, quanti dolci pensier, quanto disio menò costoro al doloroso passo!.
        Poi mi rivolsi a loro e parla’ io, e cominciai: Francesca, i tuoi martìri a lagrimar mi fanno tristo e pio.
        Ma dimmi: al tempo d’i dolci sospiri, a che e come concedette amore che conosceste i dubbiosi disiri?.
        E quella a me: Nessun maggior dolore che ricordarsi del tempo felice ne la miseria; e ciò sa ’l tuo dottore.
        Ma s’a conoscer la prima radice del nostro amor tu hai cotanto affetto, dirò come colui che piange e dice.
        Noi leggiavamo un giorno per diletto di Lancialotto come amor lo strinse; soli eravamo e sanza alcun sospetto.
        Per più fïate li occhi ci sospinse quella lettura, e scolorocci il viso; ma solo un punto fu quel che ci vinse.
        Quando leggemmo il disïato riso esser basciato da cotanto amante, questi, che mai da me non fia diviso,
        la bocca mi basciò tutto tremante. Galeotto fu ’l libro e chi lo scrisse: quel giorno più non vi leggemmo avante.
        Mentre che l’uno spirto questo disse, l’altro piangëa; sì che di pietade io venni men così com’ io morisse.
        E caddi come corpo morto cade.
        Al tornar de la mente, che si chiuse dinanzi a la pietà d’i due cognati, che di trestizia tutto mi confuse,
        novi tormenti e novi tormentati mi veggio intorno, come ch’io mi mova e ch’io mi volga, e come che io guati.
        Io sono al terzo cerchio, de la piova etterna, maladetta, fredda e greve; regola e qualità mai non l’è nova.
        Grandine grossa, acqua tinta e neve per l’aere tenebroso si riversa; pute la terra che questo riceve.
        Cerbero, fiera crudele e diversa, con tre gole caninamente latra sovra la gente che quivi è sommersa.
        Li occhi ha vermigli, la barba unta e atra, e ’l ventre largo, e unghiate le mani; graffia li spirti ed iscoia ed isquatra.
        Urlar li fa la pioggia come cani; de l’un de’ lati fanno a l’altro schermo; volgonsi spesso i miseri profani.
        Quando ci scorse Cerbero, il gran vermo, le bocche aperse e mostrocci le sanne; non avea membro che tenesse fermo.
        E ’l duca mio distese le sue spanne, prese la terra, e con piene le pugna la gittò dentro a le bramose canne.
        Qual è quel cane ch’abbaiando agogna, e si racqueta poi che ’l pasto morde, ché solo a divorarlo intende e pugna,
        cotai si fecer quelle facce lorde de lo demonio Cerbero, che ’ntrona l’anime sì, ch’esser vorrebber sorde.
        Noi passavam su per l’ombre che adona la greve pioggia, e ponavam le piante sovra lor vanità che par persona.
        Elle giacean per terra tutte quante, fuor d’una ch’a seder si levò, ratto ch’ella ci vide passarsi davante.
        O tu che se’ per questo ’nferno tratto, mi disse, riconoscimi, se sai: tu fosti, prima ch’io disfatto, fatto.
        E io a lui: L’angoscia che tu hai forse ti tira fuor de la mia mente, sì che non par ch’i’ ti vedessi mai.
        Ma dimmi chi tu se’ che ’n sì dolente loco se’ messo, e hai sì fatta pena, che, s’altra è maggio, nulla è sì spiacente.
        Ed elli a me: La tua città, ch’è piena d’invidia sì che già trabocca il sacco, seco mi tenne in la vita serena.
        Voi cittadini mi chiamaste Ciacco: per la dannosa colpa de la gola, come tu vedi, a la pioggia mi fiacco.
        E io anima trista non son sola, ché tutte queste a simil pena stanno per simil colpa. E più non fé parola.
        Io li rispuosi: Ciacco, il tuo affanno mi pesa sì, ch’a lagrimar mi ’nvita; ma dimmi, se tu sai, a che verranno
        li cittadin de la città partita; s’alcun v’è giusto; e dimmi la cagione per che l’ha tanta discordia assalita.
        E quelli a me: Dopo lunga tencione verranno al sangue, e la parte selvaggia caccerà l’altra con molta offensione.
        Poi appresso convien che questa caggia infra tre soli, e che l’altra sormonti con la forza di tal che testé piaggia.
        Alte terrà lungo tempo le fronti, tenendo l’altra sotto gravi pesi, come che di ciò pianga o che n’aonti.
        Giusti son due, e non vi sono intesi; superbia, invidia e avarizia sono le tre faville c’hanno i cuori accesi.
        Qui puose fine al lagrimabil suono. E io a lui: Ancor vo’ che mi ’nsegni e che di più parlar mi facci dono.
        Farinata e ’l Tegghiaio, che fuor sì degni, Iacopo Rusticucci, Arrigo e ’l Mosca e li altri ch’a ben far puoser li ’ngegni,
        dimmi ove sono e fa ch’io li conosca; ché gran disio mi stringe di savere se ’l ciel li addolcia o lo ’nferno li attosca.
        E quelli: Ei son tra l’anime più nere; diverse colpe giù li grava al fondo: se tanto scendi, là i potrai vedere.
        Ma quando tu sarai nel dolce mondo, priegoti ch’a la mente altrui mi rechi: più non ti dico e più non ti rispondo.
        Li diritti occhi torse allora in biechi; guardommi un poco e poi chinò la testa: cadde con essa a par de li altri ciechi.
        E ’l duca disse a me: Più non si desta di qua dal suon de l’angelica tromba, quando verrà la nimica podesta:
        ciascun rivederà la trista tomba, ripiglierà sua carne e sua figura, udirà quel ch’in etterno rimbomba.
        Sì trapassammo per sozza mistura de l’ombre e de la pioggia, a passi lenti, toccando un poco la vita futura;
        per ch’io dissi: Maestro, esti tormenti crescerann’ ei dopo la gran sentenza, o fier minori, o saran sì cocenti?.
        Ed elli a me: Ritorna a tua scïenza, che vuol, quanto la cosa è più perfetta, più senta il bene, e così la doglienza.
        Tutto che questa gente maladetta in vera perfezion già mai non vada, di là più che di qua essere aspetta.
        Noi aggirammo a tondo quella strada, parlando più assai ch’i’ non ridico; venimmo al punto dove si digrada:
        quivi trovammo Pluto, il gran nemico.
        Pape Satàn, pape Satàn aleppe!, cominciò Pluto con la voce chioccia; e quel savio gentil, che tutto seppe,
        disse per confortarmi: Non ti noccia la tua paura; ché, poder ch’elli abbia, non ci torrà lo scender questa roccia.
        Poi si rivolse a quella ’nfiata labbia, e disse: Taci, maladetto lupo! consuma dentro te con la tua rabbia.
        Non è sanza cagion l’andare al cupo: vuolsi ne l’alto, là dove Michele fé la vendetta del superbo strupo.
        Quali dal vento le gonfiate vele caggiono avvolte, poi che l’alber fiacca, tal cadde a terra la fiera crudele.
        Così scendemmo ne la quarta lacca, pigliando più de la dolente ripa che ’l mal de l’universo tutto insacca.
        Ahi giustizia di Dio! tante chi stipa nove travaglie e pene quant’ io viddi? e perché nostra colpa sì ne scipa?
        Come fa l’onda là sovra Cariddi, che si frange con quella in cui s’intoppa, così convien che qui la gente riddi.
        Qui vid’ i’ gente più ch’altrove troppa, e d’una parte e d’altra, con grand’ urli, voltando pesi per forza di poppa.
        Percotëansi ’ncontro; e poscia pur lì si rivolgea ciascun, voltando a retro, gridando: Perché tieni? e Perché burli?.
        Così tornavan per lo cerchio tetro da ogne mano a l’opposito punto, gridandosi anche loro ontoso metro;
        poi si volgea ciascun, quand’ era giunto, per lo suo mezzo cerchio a l’altra giostra. E io, ch’avea lo cor quasi compunto,
        dissi: Maestro mio, or mi dimostra che gente è questa, e se tutti fuor cherci questi chercuti a la sinistra nostra.
        Ed elli a me: Tutti quanti fuor guerci sì de la mente in la vita primaia, che con misura nullo spendio ferci.
        Assai la voce lor chiaro l’abbaia, quando vegnono a’ due punti del cerchio dove colpa contraria li dispaia.
        Questi fuor cherci, che non han coperchio piloso al capo, e papi e cardinali, in cui usa avarizia il suo soperchio.
        E io: Maestro, tra questi cotali dovre’ io ben riconoscere alcuni che furo immondi di cotesti mali.
        Ed elli a me: Vano pensiero aduni: la sconoscente vita che i fé sozzi, ad ogne conoscenza or li fa bruni.
        In etterno verranno a li due cozzi: questi resurgeranno del sepulcro col pugno chiuso, e questi coi crin mozzi.
        Mal dare e mal tener lo mondo pulcro ha tolto loro, e posti a questa zuffa: qual ella sia, parole non ci appulcro.
        Or puoi, figliuol, veder la corta buffa d’i ben che son commessi a la fortuna, per che l’umana gente si rabbuffa;
        ché tutto l’oro ch’è sotto la luna e che già fu, di quest’ anime stanche non poterebbe farne posare una.
        Maestro mio, diss’ io, or mi dì anche: questa fortuna di che tu mi tocche, che è, che i ben del mondo ha sì tra branche?.
        E quelli a me: Oh creature sciocche, quanta ignoranza è quella che v’offende! Or vo’ che tu mia sentenza ne ’mbocche.
        Colui lo cui saver tutto trascende, fece li cieli e diè lor chi conduce sì, ch’ogne parte ad ogne parte splende,
        distribuendo igualmente la luce. Similemente a li splendor mondani ordinò general ministra e duce
        che permutasse a tempo li ben vani di gente in gente e d’uno in altro sangue, oltre la difension d’i senni umani;
        per ch’una gente impera e l’altra langue, seguendo lo giudicio di costei, che è occulto come in erba l’angue.
        Vostro saver non ha contasto a lei: questa provede, giudica, e persegue suo regno come il loro li altri dèi.
        Le sue permutazion non hanno triegue: necessità la fa esser veloce; sì spesso vien chi vicenda consegue.
        Quest’ è colei ch’è tanto posta in croce pur da color che le dovrien dar lode, dandole biasmo a torto e mala voce;
        ma ella s’è beata e ciò non ode: con l’altre prime creature lieta volve sua spera e beata si gode.
        Or discendiamo omai a maggior pieta; già ogne stella cade che saliva quand’ io mi mossi, e ’l troppo star si vieta.
        Noi ricidemmo il cerchio a l’altra riva sovr’ una fonte che bolle e riversa per un fossato che da lei deriva.
        L’acqua era buia assai più che persa; e noi, in compagnia de l’onde bige, intrammo giù per una via diversa.
        In la palude va c’ha nome Stige questo tristo ruscel, quand’ è disceso al piè de le maligne piagge grige.
        E io, che di mirare stava inteso, vidi genti fangose in quel pantano, ignude tutte, con sembiante offeso.
        Queste si percotean non pur con mano, ma con la testa e col petto e coi piedi, troncandosi co’ denti a brano a brano.
        Lo buon maestro disse: Figlio, or vedi l’anime di color cui vinse l’ira; e anche vo’ che tu per certo credi
        che sotto l’acqua è gente che sospira, e fanno pullular quest’ acqua al summo, come l’occhio ti dice, u’ che s’aggira.
        Fitti nel limo dicon: “Tristi fummo ne l’aere dolce che dal sol s’allegra, portando dentro accidïoso fummo:
        or ci attristiam ne la belletta negra”. Quest’ inno si gorgoglian ne la strozza, ché dir nol posson con parola integra.
        Così girammo de la lorda pozza grand’ arco tra la ripa secca e ’l mézzo, con li occhi vòlti a chi del fango ingozza.
        Venimmo al piè d’una torre al da sezzo.
        Io dico, seguitando, ch’assai prima che noi fossimo al piè de l’alta torre, li occhi nostri n’andar suso a la cima
        per due fiammette che i vedemmo porre, e un’altra da lungi render cenno, tanto ch’a pena il potea l’occhio tòrre.
        E io mi volsi al mar di tutto ’l senno; dissi: Questo che dice? e che risponde quell’ altro foco? e chi son quei che ’l fenno?.
        Ed elli a me: Su per le sucide onde già scorgere puoi quello che s’aspetta, se ’l fummo del pantan nol ti nasconde.
        Corda non pinse mai da sé saetta che sì corresse via per l’aere snella, com’ io vidi una nave piccioletta
        venir per l’acqua verso noi in quella, sotto ’l governo d’un sol galeoto, che gridava: Or se’ giunta, anima fella!.
        Flegïàs, Flegïàs, tu gridi a vòto, disse lo mio segnore, a questa volta: più non ci avrai che sol passando il loto.
        Qual è colui che grande inganno ascolta che li sia fatto, e poi se ne rammarca, fecesi Flegïàs ne l’ira accolta.
        Lo duca mio discese ne la barca, e poi mi fece intrare appresso lui; e sol quand’ io fui dentro parve carca.
        Tosto che ’l duca e io nel legno fui, segando se ne va l’antica prora de l’acqua più che non suol con altrui.
        Mentre noi corravam la morta gora, dinanzi mi si fece un pien di fango, e disse: Chi se’ tu che vieni anzi ora?.
        E io a lui: S’i’ vegno, non rimango; ma tu chi se’, che sì se’ fatto brutto?. Rispuose: Vedi che son un che piango.
        E io a lui: Con piangere e con lutto, spirito maladetto, ti rimani; ch’i’ ti conosco, ancor sie lordo tutto.
        Allor distese al legno ambo le mani; per che ’l maestro accorto lo sospinse, dicendo: Via costà con li altri cani!.
        Lo collo poi con le braccia mi cinse; basciommi ’l volto e disse: Alma sdegnosa, benedetta colei che ’n te s’incinse!
        Quei fu al mondo persona orgogliosa; bontà non è che sua memoria fregi: così s’è l’ombra sua qui furïosa.
        Quanti si tegnon or là sù gran regi che qui staranno come porci in brago, di sé lasciando orribili dispregi!.
        E io: Maestro, molto sarei vago di vederlo attuffare in questa broda prima che noi uscissimo del lago.
        Ed elli a me: Avante che la proda ti si lasci veder, tu sarai sazio: di tal disïo convien che tu goda.
        Dopo ciò poco vid’ io quello strazio far di costui a le fangose genti, che Dio ancor ne lodo e ne ringrazio.
        Tutti gridavano: A Filippo Argenti!; e ’l fiorentino spirito bizzarro in sé medesmo si volvea co’ denti.
        Quivi il lasciammo, che più non ne narro; ma ne l’orecchie mi percosse un duolo, per ch’io avante l’occhio intento sbarro.
        Lo buon maestro disse: Omai, figliuolo, s’appressa la città c’ha nome Dite, coi gravi cittadin, col grande stuolo.
        E io: Maestro, già le sue meschite là entro certe ne la valle cerno, vermiglie come se di foco uscite
        fossero. Ed ei mi disse: Il foco etterno ch’entro l’affoca le dimostra rosse, come tu vedi in questo basso inferno.
        Noi pur giugnemmo dentro a l’alte fosse che vallan quella terra sconsolata: le mura mi parean che ferro fosse.
        Non sanza prima far grande aggirata, venimmo in parte dove il nocchier forte Usciteci, gridò: qui è l’intrata.
        Io vidi più di mille in su le porte da ciel piovuti, che stizzosamente dicean: Chi è costui che sanza morte
        va per lo regno de la morta gente?. E ’l savio mio maestro fece segno di voler lor parlar segretamente.
        Allor chiusero un poco il gran disdegno e disser: Vien tu solo, e quei sen vada che sì ardito intrò per questo regno.
        Sol si ritorni per la folle strada: pruovi, se sa; ché tu qui rimarrai, che li ha’ iscorta sì buia contrada.
        Pensa, lettor, se io mi sconfortai nel suon de le parole maladette, ché non credetti ritornarci mai.
        O caro duca mio, che più di sette volte m’hai sicurtà renduta e tratto d’alto periglio che ’ncontra mi stette,
        non mi lasciar, diss’ io, così disfatto; e se ’l passar più oltre ci è negato, ritroviam l’orme nostre insieme ratto.
        E quel segnor che lì m’avea menato, mi disse: Non temer; ché ’l nostro passo non ci può tòrre alcun: da tal n’è dato.
        Ma qui m’attendi, e lo spirito lasso conforta e ciba di speranza buona, ch’i’ non ti lascerò nel mondo basso.
        Così sen va, e quivi m’abbandona lo dolce padre, e io rimagno in forse, che sì e no nel capo mi tenciona.
        Udir non potti quello ch’a lor porse; ma ei non stette là con essi guari, che ciascun dentro a pruova si ricorse.
        Chiuser le porte que’ nostri avversari nel petto al mio segnor, che fuor rimase e rivolsesi a me con passi rari.
        Li occhi a la terra e le ciglia avea rase d’ogne baldanza, e dicea ne’ sospiri: Chi m’ha negate le dolenti case!.
        E a me disse: Tu, perch’ io m’adiri, non sbigottir, ch’io vincerò la prova, qual ch’a la difension dentro s’aggiri.
        Questa lor tracotanza non è nova; ché già l’usaro a men segreta porta, la qual sanza serrame ancor si trova.
        Sovr’ essa vedestù la scritta morta: e già di qua da lei discende l’erta, passando per li cerchi sanza scorta,
        tal che per lui ne fia la terra aperta.
        Quel color che viltà di fuor mi pinse veggendo il duca mio tornare in volta, più tosto dentro il suo novo ristrinse.
        Attento si fermò com’ uom ch’ascolta; ché l’occhio nol potea menare a lunga per l’aere nero e per la nebbia folta.
        Pur a noi converrà vincer la punga, cominciò el, se non . . . Tal ne s’offerse. Oh quanto tarda a me ch’altri qui giunga!.
        I’ vidi ben sì com’ ei ricoperse lo cominciar con l’altro che poi venne, che fur parole a le prime diverse;
        ma nondimen paura il suo dir dienne, perch’ io traeva la parola tronca forse a peggior sentenzia che non tenne.
        In questo fondo de la trista conca discende mai alcun del primo grado, che sol per pena ha la speranza cionca?.
        Questa question fec’ io; e quei Di rado incontra, mi rispuose, che di noi faccia il cammino alcun per qual io vado.
        Ver è ch’altra fïata qua giù fui, congiurato da quella Eritón cruda che richiamava l’ombre a’ corpi sui.
        Di poco era di me la carne nuda, ch’ella mi fece intrar dentr’ a quel muro, per trarne un spirto del cerchio di Giuda.
        Quell’ è ’l più basso loco e ’l più oscuro, e ’l più lontan dal ciel che tutto gira: ben so ’l cammin; però ti fa sicuro.
        Questa palude che ’l gran puzzo spira cigne dintorno la città dolente, u’ non potemo intrare omai sanz’ ira.
        E altro disse, ma non l’ho a mente; però che l’occhio m’avea tutto tratto ver’ l’alta torre a la cima rovente,
        dove in un punto furon dritte ratto tre furïe infernal di sangue tinte, che membra feminine avieno e atto,
        e con idre verdissime eran cinte; serpentelli e ceraste avien per crine, onde le fiere tempie erano avvinte.
        E quei, che ben conobbe le meschine de la regina de l’etterno pianto, Guarda, mi disse, le feroci Erine.
        Quest’ è Megera dal sinistro canto; quella che piange dal destro è Aletto; Tesifón è nel mezzo; e tacque a tanto.
        Con l’unghie si fendea ciascuna il petto; battiensi a palme e gridavan sì alto, ch’i’ mi strinsi al poeta per sospetto.
        Vegna Medusa: sì ’l farem di smalto, dicevan tutte riguardando in giuso; mal non vengiammo in Tesëo l’assalto.
        Volgiti ’n dietro e tien lo viso chiuso; ché se ’l Gorgón si mostra e tu ’l vedessi, nulla sarebbe di tornar mai suso.
        Così disse ’l maestro; ed elli stessi mi volse, e non si tenne a le mie mani, che con le sue ancor non mi chiudessi.
        O voi ch’avete li ’ntelletti sani, mirate la dottrina che s’asconde sotto ’l velame de li versi strani.
        E già venìa su per le torbide onde un fracasso d’un suon, pien di spavento, per cui tremavano amendue le sponde,
        non altrimenti fatto che d’un vento impetüoso per li avversi ardori, che fier la selva e sanz’ alcun rattento
        li rami schianta, abbatte e porta fori; dinanzi polveroso va superbo, e fa fuggir le fiere e li pastori.
        Li occhi mi sciolse e disse: Or drizza il nerbo del viso su per quella schiuma antica per indi ove quel fummo è più acerbo.
        Come le rane innanzi a la nimica biscia per l’acqua si dileguan tutte, fin ch’a la terra ciascuna s’abbica,
        vid’ io più di mille anime distrutte fuggir così dinanzi ad un ch’al passo passava Stige con le piante asciutte.
        Dal volto rimovea quell’ aere grasso, menando la sinistra innanzi spesso; e sol di quell’ angoscia parea lasso.
        Ben m’accorsi ch’elli era da ciel messo, e volsimi al maestro; e quei fé segno ch’i’ stessi queto ed inchinassi ad esso.
        Ahi quanto mi parea pien di disdegno! Venne a la porta e con una verghetta l’aperse, che non v’ebbe alcun ritegno.
        O cacciati del ciel, gente dispetta, cominciò elli in su l’orribil soglia, ond’ esta oltracotanza in voi s’alletta?
        Perché recalcitrate a quella voglia a cui non puote il fin mai esser mozzo, e che più volte v’ha cresciuta doglia?
        Che giova ne le fata dar di cozzo? Cerbero vostro, se ben vi ricorda, ne porta ancor pelato il mento e ’l gozzo.
        Poi si rivolse per la strada lorda, e non fé motto a noi, ma fé sembiante d’omo cui altra cura stringa e morda
        che quella di colui che li è davante; e noi movemmo i piedi inver’ la terra, sicuri appresso le parole sante.
        Dentro li ’ntrammo sanz’ alcuna guerra; e io, ch’avea di riguardar disio la condizion che tal fortezza serra,
        com’ io fui dentro, l’occhio intorno invio: e veggio ad ogne man grande campagna, piena di duolo e di tormento rio.
        Sì come ad Arli, ove Rodano stagna, sì com’ a Pola, presso del Carnaro ch’Italia chiude e suoi termini bagna,
        fanno i sepulcri tutt’ il loco varo, così facevan quivi d’ogne parte, salvo che ’l modo v’era più amaro;
        ché tra li avelli fiamme erano sparte, per le quali eran sì del tutto accesi, che ferro più non chiede verun’ arte.
        Tutti li lor coperchi eran sospesi, e fuor n’uscivan sì duri lamenti, che ben parean di miseri e d’offesi.
        E io: Maestro, quai son quelle genti che, seppellite dentro da quell’ arche, si fan sentir coi sospiri dolenti?.
        E quelli a me: Qui son li eresïarche con lor seguaci, d’ogne setta, e molto più che non credi son le tombe carche.
        Simile qui con simile è sepolto, e i monimenti son più e men caldi. E poi ch’a la man destra si fu vòlto,
        passammo tra i martìri e li alti spaldi.
        Ora sen va per un secreto calle, tra ’l muro de la terra e li martìri, lo mio maestro, e io dopo le spalle.
        O virtù somma, che per li empi giri mi volvi, cominciai, com’ a te piace, parlami, e sodisfammi a’ miei disiri.
        La gente che per li sepolcri giace potrebbesi veder? già son levati tutt’ i coperchi, e nessun guardia face.
        E quelli a me: Tutti saran serrati quando di Iosafàt qui torneranno coi corpi che là sù hanno lasciati.
        Suo cimitero da questa parte hanno con Epicuro tutti suoi seguaci, che l’anima col corpo morta fanno.
        Però a la dimanda che mi faci quinc’ entro satisfatto sarà tosto, e al disio ancor che tu mi taci.
        E io: Buon duca, non tegno riposto a te mio cuor se non per dicer poco, e tu m’hai non pur mo a ciò disposto.
        O Tosco che per la città del foco vivo ten vai così parlando onesto, piacciati di restare in questo loco.
        La tua loquela ti fa manifesto di quella nobil patrïa natio, a la qual forse fui troppo molesto.
        Subitamente questo suono uscìo d’una de l’arche; però m’accostai, temendo, un poco più al duca mio.
        Ed el mi disse: Volgiti! Che fai? Vedi là Farinata che s’è dritto: da la cintola in sù tutto ’l vedrai.
        Io avea già il mio viso nel suo fitto; ed el s’ergea col petto e con la fronte com’ avesse l’inferno a gran dispitto.
        E l’animose man del duca e pronte mi pinser tra le sepulture a lui, dicendo: Le parole tue sien conte.
        Com’ io al piè de la sua tomba fui, guardommi un poco, e poi, quasi sdegnoso, mi dimandò: Chi fuor li maggior tui?.
        Io ch’era d’ubidir disideroso, non gliel celai, ma tutto gliel’ apersi; ond’ ei levò le ciglia un poco in suso;
        poi disse: Fieramente furo avversi a me e a miei primi e a mia parte, sì che per due fïate li dispersi.
        S’ei fur cacciati, ei tornar d’ogne parte, rispuos’ io lui, l’una e l’altra fïata; ma i vostri non appreser ben quell’ arte.
        Allor surse a la vista scoperchiata un’ombra, lungo questa, infino al mento: credo che s’era in ginocchie levata.
        Dintorno mi guardò, come talento avesse di veder s’altri era meco; e poi che ’l sospecciar fu tutto spento,
        piangendo disse: Se per questo cieco carcere vai per altezza d’ingegno, mio figlio ov’ è? e perché non è teco?.
        E io a lui: Da me stesso non vegno: colui ch’attende là, per qui mi mena forse cui Guido vostro ebbe a disdegno.
        Le sue parole e ’l modo de la pena m’avean di costui già letto il nome; però fu la risposta così piena.
        Di sùbito drizzato gridò: Come? dicesti “elli ebbe”? non viv’ elli ancora? non fiere li occhi suoi lo dolce lume?.
        Quando s’accorse d’alcuna dimora ch’io facëa dinanzi a la risposta, supin ricadde e più non parve fora.
        Ma quell’ altro magnanimo, a cui posta restato m’era, non mutò aspetto, né mosse collo, né piegò sua costa;
        e sé continüando al primo detto, S’elli han quell’ arte, disse, male appresa, ciò mi tormenta più che questo letto.
        Ma non cinquanta volte fia raccesa la faccia de la donna che qui regge, che tu saprai quanto quell’ arte pesa.
        E se tu mai nel dolce mondo regge, dimmi: perché quel popolo è sì empio incontr’ a’ miei in ciascuna sua legge?.
        Ond’ io a lui: Lo strazio e ’l grande scempio che fece l’Arbia colorata in rosso, tal orazion fa far nel nostro tempio.
        Poi ch’ebbe sospirando il capo mosso, A ciò non fu’ io sol, disse, né certo sanza cagion con li altri sarei mosso.
        Ma fu’ io solo, là dove sofferto fu per ciascun di tòrre via Fiorenza, colui che la difesi a viso aperto.
        Deh, se riposi mai vostra semenza, prega’ io lui, solvetemi quel nodo che qui ha ’nviluppata mia sentenza.
        El par che voi veggiate, se ben odo, dinanzi quel che ’l tempo seco adduce, e nel presente tenete altro modo.
        Noi veggiam, come quei c’ha mala luce, le cose, disse, che ne son lontano; cotanto ancor ne splende il sommo duce.
        Quando s’appressano o son, tutto è vano nostro intelletto; e s’altri non ci apporta, nulla sapem di vostro stato umano.
        Però comprender puoi che tutta morta fia nostra conoscenza da quel punto che del futuro fia chiusa la porta.
        Allor, come di mia colpa compunto, dissi: Or direte dunque a quel caduto che ’l suo nato è co’ vivi ancor congiunto;
        e s’i’ fui, dianzi, a la risposta muto, fate i saper che ’l fei perché pensava già ne l’error che m’avete soluto.
        E già ’l maestro mio mi richiamava; per ch’i’ pregai lo spirto più avaccio che mi dicesse chi con lu’ istava.
        Dissemi: Qui con più di mille giaccio: qua dentro è ’l secondo Federico e ’l Cardinale; e de li altri mi taccio.
        Indi s’ascose; e io inver’ l’antico poeta volsi i passi, ripensando a quel parlar che mi parea nemico.
        Elli si mosse; e poi, così andando, mi disse: Perché se’ tu sì smarrito?. E io li sodisfeci al suo dimando.
        La mente tua conservi quel ch’udito hai contra te, mi comandò quel saggio; e ora attendi qui, e drizzò ’l dito:
        quando sarai dinanzi al dolce raggio di quella il cui bell’ occhio tutto vede, da lei saprai di tua vita il vïaggio.
        Appresso mosse a man sinistra il piede: lasciammo il muro e gimmo inver’ lo mezzo per un sentier ch’a una valle fiede,
        che ’nfin là sù facea spiacer suo lezzo.";

        /// <summary>
        /// Robinsono Kruso (Esperanto) - Daniel Defoe
        /// </summary>
        /// <remarks>This text is under public domain</remarks>
        static readonly string KrusoEsperanto = @"
        mi naskigxis en jorko anglujo je marto kiu estas la
        sesjarrego de la regxo karolo la unua infane mi sentadis grandan
        deziron por pasigi mian vivon sur la maro kaj pliagxante la deziro
        plifortigxis gxis fine mi forlasis mian lernejon kaj hejmon kaj
        piede mi trovis mian vojon al hull kie mi baldaux trovis okupadon sur
        sxipo

        post kiam ni velveturis kelke da tagoj okazis ventego kaj kvinanokte
        la sxipo enfendigxis cxiuj al la pumpiloj rapidis la sxipon ni sentis
        gxemi en cxiuj siaj tabuloj kaj gxian trabajxon ektremi de la antauxa gxis
        la posta parto kaj baldaux klarigxis ke ne estas ia espero por gxi kaj
        ke cxio kion ni povas fari estas savi niajn vivojn

        unue ni pafadis pafilegojn por venigi helpon kaj post kelke da
        tempo sxipo kusxante ne malproksime alsendis boaton por helpi nin sed
        la maro estis tro maltrankvila por gxi restadi sxipflanke tial ni
        eljxetis sxnuregon kiun la boatanoj ekkaptis kaj firme fiksis kaj
        tiamaniere ni cxiuj enboatigxis

        tamen vanigxis en tia maltrankvila maro por peni albordigxi la sxipon
        kiu alsendis la virojn aux aluzi la remilojn de la boato kaj ni ne
        povis ion fari krom gxin lasi peligxi teron

        duonhore nia sxipo trafis rifon kaj subakvigxis kaj gxin ni ne vidis
        plu tre malrapide ni alproksimigxis teron kiun iafoje ni vidis kiam
        ajn la boato levigxis sur la supro de ia alta ondo kaj tie ni vidis
        homojn kurante amase tien kaj reen havante unu celon savi nin

        fine gxojege ni surterigxis kie bonsxance ni renkontis amikojn kiuj
        donis al ni helpon por reveturi al hull kaj se tiam mi havus la
        bonan sencon por iri hejmon estus pli bone por mi

        la viro kies sxipo subakvigxis diris kun grava mieno junulo ne iru
        plu surmaron tiu ne estas la vivmaniero por vi kial do sinjoro
        vi mem iros plu surmaron tiu estas alia afero mi estas elnutrita
        por la maro sed vi ne estas vi venis sur mian sxipon por eltrovi la
        staton de vivo surmara kaj vi povas diveni tion kio okazos al vi se
        vi ne reiros hejmon dio ne benos vin kaj eble vi kauxzis tiun-cxi
        tutan malbonon al ni

        mi ne parolis alian vorton al li kiun vojon li iris mi nek scias
        nek deziris sciigxi cxar mi estis ofendita pro tiu-cxi malgxentila
        parolado mi multe pensis cxu iri hejmon aux cxu iradi surmaron honto
        detenis min pri iri hejmon kaj mi ne povis decidi la vivkuron kiun
        mi estis ironta

        kiel estis mia sorto travive cxiam elekti la plej malbonon tiel same
        mi nun faris mi havis oron en mia monujo kaj bonan vestajxon sur mia
        korpo sed surmaron mi ree iris

        sed nun mi havis pli malbonan sxancon ol iam cxar kiam ni estis tre
        malproksime enmaro kelke da turkoj en sxipeto plencxase alproksimigxis
        al ni ni levis tiom da veloj kiom niaj velstangoj povis elporti por
        ke ni forkuru de ili tamen malgraux tio ni vidis ke niaj malamikoj
        pli kaj pli alproksimigxis kaj certigxis ke baldaux ili atingos nian
        sxipon

        fine ili atingis nin sed ni direktis niajn pafilegojn sur ilin kio
        kauxzis portempe ke ili deflanku sian vojon sed ili dauxrigis pafadon
        sur ni tiel longe kiel ili estis en pafspaco proksimigxante la duan
        fojon kelkaj viroj atingis la ferdekon de nia sxipo kaj ektrancxis la
        velojn kaj ekfaris cxiuspecajn difektajxojn tial post kiam dek el
        niaj sxipanoj kusxas mortitaj kaj la plimulto el la ceteraj havas
        vundojn ni kapitulacis

        la cxefo de la turkoj prenis min kiel sian rabajxon al haveno okupita
        de mauxroj li ne agis al mi tiel malbone kiel mi lin unue jugxis sed
        li min laborigis kun la ceteraj de siaj sklavoj tio estis sxangxo en
        mia vivo kiun mi neniam antauxvidis ho ve kiom mia koro malgxojis
        pensante pri tiuj kiujn mi lasis hejme al kiuj mi ne montris tiom da
        komplezemo kiom diri adiauxi kiam mi iris surmaron aux sciigi tion
        kion mi intencas fari

        tamen cxio kion mi travivis tiam estas nur antauxgusto de la penadoj
        kaj zorgoj kiujn de tiam estis mia sorto suferi

        unue mi pensis ke la turko kunprenos min kun si kiam li ree iros
        surmaron kaj ke mi iel povos liberigxi sed la espero nelonge dauxris
        cxar tiatempe li lasis min surtere por prizorgi liajn rikoltojn
        tiamaniere mi vivis du jarojn tamen la turko konante kaj vidante min
        plu min pli kaj pli liberigis li unufoje aux dufoje cxiusemajne
        veturis en sia boato por kapti iajn platfisxojn kaj iafoje li
        kunprenis min kaj knabon kun si cxar ni estas rapidaj cxe tia sporto
        kaj tial li pli kaj pli sxatis min

        unu tagon la turko elsendis min viron kaj knabon boate por kapti
        kelke da fisxoj surmare okazas tia densa nebulo ke dekduhore ni ne
        povas vidi la teron kvankam ni ne estas pli ol duonmejlon 00
        metrojn de la terbordo kaj morgauxtage kiam la suno levigxis nia
        boato estas enmaro almenaux dek mejlojn  kilometrojn de la
        terbordo la vento vigle blovis kaj ni cxiuj tre bezonis nutrajxon sed
        fine per la helpo de remiloj kaj veloj ni sendangxere reatingis la
        terbordon

        kiam la turko sciigxis kiamaniere ni vojperdis li diris ke de nun
        kiam li velveturos li prenos boaton kiu enhavos cxion kion ni
        bezonus se ni longatempe estus detenataj surmare tial li farigis
        grandan kajuton en la longboato de sia sxipo kiel ankaux cxambron por ni
        sklavoj unu tagon li min sendis por ke mi ordigu la boaton pro tio
        ke li havas du amikojn kiuj intencas veturi kun li por fisxkapti sed
        kiam la tempo alvenis ili ne veturas tial li sendis min viron kaj
        knabon -- kies nomo estas zuro -- por kapti kelke da fisxoj por la
        gastoj kiuj estas vespermangxontaj kun li

        subite eniris en mian kapon la ideo ke nun estas bona okazo boate
        forkuri kaj liberigxi tial mi tuj prenis tiom da nutrajxo kiom mi
        povas havigi kaj mi diris al la viro ke estus tro malrespekte
        mangxante la panon metitan en la boaton por la turko li diris ke li
        pensas tiel same tial li alportis sakon da rizo kaj kelke da ruskoj
        kukoj

        dum la viro estis surtere mi provizis iom da vino pecegon da vakso
        segilon hakilon fosilon iom da sxnurego kaj cxiuspecajn objektojn
        kiuj eble estos utilaj al ni mi sciis kie trovigxas la vinkesto de la
        turko kaj mi gxin metis surboaton dum la viro estas surtere per alia
        ruzo mi havigis cxion kion mi bezonis mi diris al la knabo la
        pafiloj de la turko estas en la boato sed ne trovigxas ia pafajxo cxu
        vi pensas ke vi povas havigi iom da gxi vi scias kie gxi estas
        konservata kaj eble ni volos pafi birdon aux du li do alportis kesto
        kaj saketon kiuj enhavas cxion kion ni eble bezonas por la pafiloj
        tiujn-cxi mi metis surboaton kaj poste velveturis por fisxkapti

        la vento blovis de la nordo aux nordokcidento tia vento estis malbona
        por mi cxar se gxi estus de la sudo mi estus povinta velveturi al la
        terbordo de hispanujo tamen de kiu ajn loko la vento blovos mi
        estis decidinta forkuri kaj lasi la ceterajn al ilia sorto mi do
        mallevis miajn hokfadenojn kvazaux fisxkapti sed mi zorgis ke mi havu
        malbonan sukceson kaj kiam la fisxoj mordis mi ilin ne eltiris cxar
        mi deziris ke la mauxro ilin ne vidu mi diris al li tiu-cxi loko
        estas nebona ni ne kaptos fisxojn tie-cxi ni devas iom antauxen iri
        nu la mauxro pensis ke tion fari ne estos malbone li levis la
        velojn kaj cxar la direktilo estis en miaj manoj mi elsendis la
        boaton unu mejlon aux plu enmaron kaj poste gxin haltigis kvazaux mi
        intencas fisxkapti

        nun mi pripensis tiu-cxi estas mia okazo liberigxi tial mi transdonis
        la direktilon al la knabo kaj tiam ekprenis la mauxron cxirkaux la
        talio kaj eljxetis lin el la boato

        malsupren li falis sed baldaux reaperis por ke li povis nagxi kvazaux
        anaso li diris ke li volonte irus cxirkaux la mondo kun mi se mi
        enprenus lin

        iom timante ke li surrampos la boatflankon kaj reenigxos perforte mi
        direktis mian pafilon sur lin kaj diris vi facile povas nagxi
        alteron se vi tion deziras tial rapidigxu tien plie se vi reen
        alproksimigxos la boaton vi ricevos kuglon tra la kapo cxar mi de nun
        intencas esti libera viro

        tiam li eknagxis kaj sendube sendangxere atingis la terbordon cxar la
        maro estis tre trankvila

        unue mi intencis kunpreni la mauxron kun mi kaj nagxigi zuron alteron
        sed la mauxro ne estis viro pri kiu mi povis konfidi

        post kiam li forigxis mi diris al zuro se vi jxuros ke vi estos
        fidela al mi vi iam farigxos grava viro se vi ne jxuros mi certe
        ankaux vin eljxetos el la boato

        la knabo tiel dolcxe ridetis kiam li jxuris resti fidela al mi ke mi
        lin ne povis dubi en mia koro

        dum ankoraux ni povis vidi la mauxron survoje alteren ni antauxen iris
        enmaron por ke li kaj tiuj kiuj nin vidis de la terbordo kredu ke
        ni iros al la influejo de la markolo cxar neniu velveturis al la suda
        marbordo cxar tie logxas gento da homoj kiuj laux sciigoj mortigas kaj
        mangxas siajn malamikojn

        tiam mi direktis mian veturadon oriente por ke ni lauxlongiru la
        marbordon kaj havante favoron venton kaj trankvilan maron ni
        morgauxtagmeze estis malapud kaj preter la povo de la turko

        ankoraux mi timis ke mi estus kaptota de la mauxroj tial mi ne volis
        iri surteron tage duonlume ni direktis nian boaton alteren kaj
        atingis la enfluejon riveretan de kiu mi pensis ni povos nagxi
        surteron kaj tiam rigardi la cxirkauxajxojn sed kiam malheligxis la
        lumo ni auxdis strangajn sonojn bojojn kriegojn gruntojn
        blekadojn la malfelicxa knabo diris ke li ne kuragxas iri surteron
        antaux la tagigxo nu mi diris tiuokaze ni atendu sed tage
        povas vidi nin la homoj kiuj eble nin pli malhelpos ol sovagxaj
        bestoj tiam ni pafilos ilin ridante diris zuro kaj forkurigu
        ilin

        mi gxojis vidi ke la knabo montras tiom da gajeco kaj mi donis al li
        iom da pano kaj rizo tiunokte ni silente ripozis sed ne longe
        dormis cxar post kelke da horoj iaj grandegaj bestoj malsuprenvenis
        al la maro por sin bani la malfelicxa knabo ektremis de kapo al
        piedoj pro la vidajxo unu el tiuj bestoj alproksimigxis nian boaton
        kaj kvankam estis tro mallume por gxin bone vidi ni auxdis gxin blovi
        kaj sciis pro gxia bruego ke gxi certe estas granda fine la bruto
        tiom alproksimigxis la boaton kiom la longeco de du remiloj tial mi
        pafis sur gxin kaj gxi nagxis alteren

        la blekegoj kaj kriegoj kiujn faris bestoj kaj birdoj pro la bruo de
        mia pafilo sxajne montris ke ni faris malbonan elekton por surterejo
        sed vole ne vole ni devis iri surtere por sercxi fresxan fonton por
        ke ni povu plenigi niajn barelojn zuro diris ke li eltrovus cxu la
        fontaj akvoj tauxgas por trinki se mi permesus al li preni unu el la
        botelegoj kaj ke li gxin reportos plenigitan se la akvo estas bona
        kial vi volas iri mi diris kial mi ne estas ironta vi povas
        resti en la boato kontrauxe zuro diris se la sovagxuloj venos ili
        min mangxu sed vi forkuru mi devis ami la junulon pro la afabla
        parolado nu mi diris ni ambaux iros kaj se la sovagxuloj venos
        ni ilin mortigu ja ili ne mangxos aux vin aux min

        mi donis al zuro iom da rumo el la kesto de la turko por reforti lin
        kaj ni iris surteron la knabo ekiris kun sia pafilo mejlon de la
        loko kie ni surteriris kaj li revenis kun leporo kiun li mortpafis
        kaj kiun ni gxoje kuiris kaj mangxis laux la bona novajxo kiun li
        raportis li eltrovis fonton kaj ne vidis sovagxulojn

        mi divenis ke la promontoro de la verdaj insuloj ne estas
        malproksime cxar mi vidis la supron de la granda pinto kiun kiel mi
        sciis estas apud ili mia sola espero estis ke lauxlongirante la
        terbordon ni trovos sxipon kiu ensxipigos nin kaj tiam kaj ne antaux
        tiam mi sentos kvazaux libera viro unuvorte mi konfidis mian sorton
        al la sxanco aux renkonti ian sxipon aux morti

        surteron ni ekvidis iujn homojn kiuj staras kaj rigardas nin ili
        estis nigraj kaj ne portis vestajxon mi estus irinta surteron al ili
        sed zuro -- kiu sciis plej bone -- diris ne vi iru ne vi iru tial
        mi direktis la boaton lauxteron por ke mi povu paroli kun ili kaj ili
        longaspace iradis laux ni mi ekvidis ke unu havas lancon en mano

        mi faris signojn ke ili alportu iom da nutrajxo al mi kaj ili
        siaparte faris signojn ke mi haltu mian boaton tial mi demetis la
        supran parton de mia velo kaj haltis tiam du el ili ekforkuris kaj
        duonhore revenis kun iom da sekigxita viando kaj ia greno kiu kreskas
        en tiu parto de la mondo tion-cxi ni deziregis sed ne sciis kiel
        havigi gxin cxar ni ne kuragxis iri surteron al ili nek ili kuragxis
        alproksimigxi al ni

        fine ili eltrovis peron sendangxeran por ni cxiuj alportante la
        nutrajxon al la marbordo ili gxin demetis kaj tre fortirigis si mem dum
        ni gxin prenis ni faris signojn por montri nian dankon ne havante ion
        alian kion ni povas doni al ili sed bonsxance ni baldaux kaptis
        grandan donacon por ili cxar du sovagxaj bestoj de la sama speco pri
        kiu mi jam priparolis venis plencxase de la montetoj al la maro

        ili nagxis kvazaux ili venis por sportigi cxiuj forkuris de ili krom
        tiu kiu portas la lancon unu el tiuj bestoj alproksimigxis nian
        boaton tial mi gxin atendis kun mia pafilo kaj tuj kiam gxi estis en
        pafspaco mi gxin pafis tra la kapo dufoje gxi subakvigxis kaj dufoje gxi
        suprenlevigxis kaj poste gxi nagxis alteren kaj falis senviva la viroj
        tiom timis pro la pafilbruo kiom ili antauxe timis je la vidajxo de la
        bestoj sed kiam mi faris signojn por ke ili venu al la marbordo ili
        tuj venis

        ili rapidis al sia rabajxo kaj tordante cxirkaux gxi sxnuregon ili gxin
        sendangxere eltiris surteron

        ni nun lasis niajn sovagxulojn kaj iradis dekdu tagojn plu la terbordo
        antaux ni etendis sin kvar aux kvin mejlojn  aux  kilometrojn
        bekforme kaj ni devis veturi iom de la terbordo por atingi tiun
        terpinton tiel ke ni portempe ne vidis teron

        mi konfidis la direktilon al zuro kaj sidigxis por pripensi tion kion
        estos plej bone nun fari kiam subite mi auxdis ke la knabo krias
        sxipon kun velo sxipon kun velo li ne montris multe da gxojo je la
        vidajxo opiniante ke la sxipo venis por repreni lin sed mi bone
        scias laux la sxajno ke gxi ne estas iu el la sxipoj de la turko

        mi levis kiel eble plej multe da veloj por renkonti la sxipon gxiavoje
        kaj ordonis al zuro ke li ekpafu pafilon cxar mi esperis ke se tiuj
        kiuj estas sur la ferdeko ne povus auxdi la sonon ili vidus la
        fumigadon ili ja gxin vidis kaj tuj demetis siajn velojn por ke ni
        povu atingi ilin kaj trihore ni estis cxe la sxipflanko la viroj
        parolis kun ni per la franca lingvo sed ni ne povis kompreni tion
        kion ili diras fine skoto sursxipe diris per mia lingvo kiu vi
        estas de kien vi venas mi diris al li iomvorte kiel mi liberigxis
        de la mauxroj

        tiam la sxipestro invitis min veni sxipbordon kaj ensxipis min zuron
        kaj cxiujn miajn posedajxojn mi diris al li ke li havu cxion kion mi
        havas sed li respondis vi estas rericevonta viajn posedajxojn post
        kiam ni atingos teron cxar mi por vi nur faris tion kion por mi vi
        farus samstate

        li pagis al mi multan monon por mia boato kaj diris ke mi ricevos
        egalan monon por zuro se mi lin fordonus sed mi diris al li ke
        liberigxinte kun helpo de la knabo mi lin ne volas vendi li diris ke
        estas juste kaj prave por mi tiel senti sed se mi decidus fordoni
        zuron li estus liberigota dujare tial cxar la sklavo deziris iri mi
        nenial diris ne trisemajne mi alvenis al cxiuj sanktuloj golfeto kaj
        nun mi estis liberulo

        mi ricevis multan monon por cxiujn miaj posedajxoj kaj kun gxi mi iris
        surteron sed mi tute ne sciis kion nun fari fine mi renkontis
        viron kies stato estas laux la mia kaj ni ambaux akiris pecon da tero
        por gxin prilabori mia farmilaro laux la lia estis malgranda sed ni
        produktigis la farmojn suficxe por subteni nin sed ne plu ni bezonis
        helpon kaj nun mi eksentis ke mi eraris ellasante la knabon

        mi tute ne sxatis tiun manieron de vivo kion mi pensis cxu mi venis
        tian longan vojon por fari tion kion mi lauxbone povus fari hejme kaj
        kun miaj parencoj cxirkaux mi kaj pligrandigxis mia malgxojo cxar la
        bonamiko kiu min alsxipis tien-cxi intencas nune lasi tiun-cxi
        terbordon

        kiam mi estis knabo kaj ekiris surmaron mi metis en la manojn de mia
        onklino iom da mono pri kiu mia bonamiko diris ke mi bone farus se
        mi gxin elspezus pro mia bieno tial post kiam li revenis hejmon li
        alsendis iom da gxi kontante kaj la restajxon kiel tukoj sxtofoj
        lanajxoj kaj similajxoj kiujn li acxetis mia onklino tiam metis en
        liajn manojn iom da livroj kiel donaco al li por montri sian
        dankecon pro cxio kion li faris por mi kaj per tiu mono li afable
        acxetis sklavon por mi intertempe mi jam acxetis sklavon tial mi nun
        havas du kaj cxio prosperis dum la sekvanta jaro";

        /// <summary>
        /// Le Masque - Arthur Rembaud
        /// </summary>
        /// <remarks>This text is under public domain</remarks>
        static readonly string LeMasque = @"
        contemplons ce trésor de grâces florentines
        dans l'ondulation de ce corps musculeux
        l'elégance et la force abondent soeurs divines
        cette femme morceau vraiment miraculeux
        divinement robuste adorablement mince
        est faite pour trôner sur des lits somptueux
        et charmer les loisirs d'un pontife ou d'un prince

        aussi vois ce souris fin et voluptueux
        ou la fatuité promene son extase
        ce long regard sournois langoureux et moqueur
        ce visage mignard tout encadré de gaze
        dont chaque trait nous dit avec un air vainqueur
        «la volupté m'appelle et l'amour me couronne»
        a cet etre doué de tant de majesté
        vois quel charme excitant la gentillesse donne
        approchons et tournons autour de sa beauté

        ô blaspheme de l'art ô surprise fatale
        la femme au corps divin promettant le bonheur
        par le haut se termine en monstre bicéphale

        mais non ce n'est qu'un masque un décor suborneur
        ce visage éclairé d'une exquise grimace
        et regarde voici crispée atrocement
        la véritable tete et la sincere face
        renversée a l'abri de la face qui ment
        pauvre grande beauté le magnifique fleuve
        de tes pleurs aboutit dans mon coeur soucieux
        ton mensonge m'enivre et mon âme s'abreuve
        aux flots que la douleur fait jaillir de tes yeux

        mais pourquoi pleure-t-elle elle beauté parfaite
        qui mettrait a ses pieds le genre humain vaincu
        quel mal mystérieux ronge son flanc d'athlete

        elle pleure insensé parce qu'elle a vécu
        et parce qu'elle vit mais ce qu'elle déplore
        surtout ce qui la fait frémir jusqu'aux genoux
        c'est que demain hélas il faudra vivre encore
        demain apres-demain et toujours  comme nous";

        /// <summary>
        /// Childe Harold's Pilgrimage - Canto the first (I.-X.) - Lord Byron
        /// </summary>
        /// <remarks>This text is under public domain</remarks>
        static readonly string LordByron = @"
        oh thou in hellas deemed of heavenly birth
        muse formed or fabled at the minstrels will
        since shamed full oft by later lyres on earth
        mine dares not call thee from thy sacred hill
        yet there ive wandered by thy vaunted rill
        yes sighed oer delphis longdeserted shrine
        where save that feeble fountain all is still
        nor mote my shell awake the weary nine
        to grace so plain a talethis lowly lay of mine

        whilome in albions isle there dwelt a youth
        who ne in virtues ways did take delight
        but spent his days in riot most uncouth
        and vexed with mirth the drowsy ear of night
        ah me in sooth he was a shameless wight
        sore given to revel and ungodly glee
        few earthly things found favour in his sight
        save concubines and carnal companie
        and flaunting wassailers of high and low degree

        childe harold was he hight but whence his name
        and lineage long it suits me not to say
        suffice it that perchance they were of fame
        and had been glorious in another day
        but one sad losel soils a name for aye
        however mighty in the olden time
        nor all that heralds rake from coffined clay
        nor florid prose nor honeyed lines of rhyme
        can blazon evil deeds or consecrate a crime

        childe harold basked him in the noontide sun
        disporting there like any other fly
        nor deemed before his little day was done
        one blast might chill him into misery
        but long ere scarce a third of his passed by
        worse than adversity the childe befell
        he felt the fulness of satiety
        then loathed he in his native land to dwell
        which seemed to him more lone than eremites sad cell

        for he through sins long labyrinth had run
        nor made atonement when he did amiss
        had sighed to many though he loved but one
        and that loved one alas could neer be his
        ah happy she to scape from him whose kiss
        had been pollution unto aught so chaste
        who soon had left her charms for vulgar bliss
        and spoiled her goodly lands to gild his waste
        nor calm domestic peace had ever deigned to taste

        and now childe harold was sore sick at heart
        and from his fellow bacchanals would flee
        tis said at times the sullen tear would start
        but pride congealed the drop within his ee
        apart he stalked in joyless reverie
        and from his native land resolved to go
        and visit scorching climes beyond the sea
        with pleasure drugged he almost longed for woe
        and een for change of scene would seek the shades below

        the childe departed from his fathers hall
        it was a vast and venerable pile
        so old it seemed only not to fall
        yet strength was pillared in each massy aisle
        monastic dome condemned to uses vile
        where superstition once had made her den
        now paphian girls were known to sing and smile
        and monks might deem their time was come agen
        if ancient tales say true nor wrong these holy men

        yet ofttimes in his maddest mirthful mood
        strange pangs would flash along childe harolds brow
        as if the memory of some deadly feud
        or disappointed passion lurked below
        but this none knew nor haply cared to know
        for his was not that open artless soul
        that feels relief by bidding sorrow flow
        nor sought he friend to counsel or condole
        whateer this grief mote be which he could not control

        and none did love him  though to hall and bower
        he gathered revellers from far and near
        he knew them flatterers of the festal hour
        the heartless parasites of present cheer
        yea none did love himnot his lemans dear
        but pomp and power alone are womans care
        and where these are light eros finds a feere
        maidens like moths are ever caught by glare
        and mammon wins his way where seraphs might despair

        childe harold had a mothernot forgot
        though parting from that mother he did shun
        a sister whom he loved but saw her not
        before his weary pilgrimage begun
        if friends he had he bade adieu to none
        yet deem not thence his breast a breast of steel
        ye who have known what tis to dote upon
        a few dear objects will in sadness feel
        such partings break the heart they fondly hope to heal";

        /// <summary>
        /// Tierra y Luna - Federico García Lorca
        /// </summary>
        /// <remarks>This text is under public domain</remarks>
        static readonly string Luna = @"
        me quedo con el transparente hombrecillo
        que come los huevos de la golondrina
        me quedo con el nino desnudo
        que pisotean los borrachos de brooklyn
        con las criaturas mudas que pasan bajo los arcos
        con el arroyo de venas ansioso de abrir sus manecitas

        tierra tan sólo tierra
        tierra para los manteles estremecidos
        para la pupila viciosa de nube
        para las heridas recientes y el húmedo pensamiento
        tierra para todo lo que huye de la tierra

        no es la ceniza en vilo de las cosas quemadas
        ni los muertos que mueven sus lenguas bajo los árboles
        es la tierra desnuda que bala por el cielo
        y deja atrás los grupos ligeros de ballenas

        es la tierra alegrísima imperturbable nadadora
        la que yo encuentro en el nino y en las criaturas que pasan los arcos
        viva la tierra de mi pulso y del baile de los helechos
        que deja a veces por el aire un duro perfil de faraón

        me quedo con la mujer fría
        donde se queman los musgos inocentes
        me quedo con los borrachos de brooklyn
        que pisan al nino desnudo
        me quedo con los signos desgarrados
        de la lenta comida de los osos

        pero entonces baja la luna despenada por las escaleras
        poniendo las ciudades de hule celeste y talco sensitivo
        llenando los pies de mármol la llanura sin recodos
        y olvidando bajo las sillas diminutas carcajadas de algodón

        oh diana diana diana vacía
        convexa resonancia donde la abeja se vuelve loca
        mi amor de paso tránsito larga muerte gustada
        nunca la piel ilesa de tu desnudo huido

        es tierra dios mío tierra lo que vengo buscando
        embozo de horizonte latido y sepultura
        es dolor que se acaba y amor que se consume
        torre de sangre abierta con las manos quemadas

        pero la luna subía y bajaba las escaleras
        repartiendo lentejas desangradas en los ojos
        dando escobazos de plata a los ninos de los muelles
        y borrando mi apariencia por el término del aire";

        /// <summary>
        /// Decameron - Novella Prima - Giovanni Boccaccio
        /// </summary>
        /// <remarks>This text is under public domain</remarks>
        static readonly string NovellaPrima = @"
        convenevole cosa e carissime donne che ciascheduna cosa la quale l'uomo fa
        dallo ammirabile e santo nome di colui il quale di tutte fu facitore le dea
        principio per che dovendo io al vostro novellare sí come primo dare
        cominciamento intendo da una delle sue maravigliose cose incominciare accio
        che quella udita la nostra speranza in lui sí come in cosa impermutabile si
        fermi e sempre sia da noi il suo nome lodato manifesta cosa e che sí come le
        cose temporali tutte sono transitorie e mortali cosí in sé e fuor di sé
        esser piene di noia d'angoscia e di fatica e a infiniti pericoli sogiacere
        alle quali senza niuno fallo né potremmo noi che viviamo mescolati in esse e
        che siamo parte d'esse durare né ripararci se spezial grazia di dio forza e
        avvedimento non ci prestasse la quale a noi e in noi non e da credere che
        per alcun nostro merito discenda ma dalla sua propria benignita mossa e da'
        prieghi di coloro impetrata che sí come noi siamo furon mortali e bene i
        suoi piaceri mentre furono in vita seguendo ora con lui eterni son divenuti
        e beati alli quali noi medesimi sí come a procuratori informati per
        esperienza della nostra fragilita forse non audaci di porgere i prieghi
        nostri nel cospetto di tanto giudice delle cose le quali a noi reputiamo
        oportune gli porgiamo e ancora piú in lui verso noi di pietosa liberalita
        pieno discerniamo che non potendo l'acume dell'occhio mortale nel segreto
        della divina mente trapassare in alcun modo avvien forse tal volta che da
        oppinione ingannati tale dinanzi alla sua maesta facciamo procuratore che da
        quella con etterno essilio e iscacciato e nondimeno esso al quale niuna cosa
        e occulta piú alla purita del pregator riguardando che alla sua ignoranza o
        allo essilio del pregato cosí come se quegli fosse nel suo cospetto beato
        essaudisce coloro che 'l priegano il che manifestamente potra apparire nella
        novella la quale di raccontare intendo manifestamente dico non il giudicio
        di dio ma quel degli uomini seguitando";

        /// <summary>
        /// The Raven - Edgar Allen Poe
        /// </summary>
        /// <remarks>This text is under public domain</remarks>
        static readonly string Poe = @"
        once upon a midnight dreary while i pondered weak and weary
        over many a quaint and curious volume of forgotten lore
        while i nodded nearly napping suddenly there came a tapping
        as of some one gently rapping rapping at my chamber door
        tis some visiter i muttered tapping at my chamber door
        only this and nothing more

        ah distinctly i remember it was in the bleak december
        and each separate dying ember wrought its ghost upon the floor
        eagerly i wished the morrow vainly i had sought to borrow
        from my books surcease of sorrowsorrow for the lost lenore
        for the rare and radiant maiden whom the angels name lenore
        nameless here for evermore

        and the silken sad uncertain rustling of each purple curtain
        thrilled mefilled me with fantastic terrors never felt before
        so that now to still the beating of my heart i stood repeating
        tis some visiter entreating entrance at my chamber door
        some late visiter entreating entrance at my chamber door
        this it is and nothing more

        presently my soul grew stronger hesitating then no longer
        sir said i or madam truly your forgiveness i implore
        but the fact is i was napping and so gently you came rapping
        and so faintly you came tapping tapping at my chamber door
        that i scarce was sure i heard youhere i opened wide the door
        darkness there and nothing more

        deep into that darkness peering long i stood there wondering fearing
        doubting dreaming dreams no mortals ever dared to dream before
        but the silence was unbroken and the stillness gave no token
        and the only word there spoken was the whispered word lenore
        this i whispered and an echo murmured back the word lenore
        merely this and nothing more

        back into the chamber turning all my soul within me burning
        soon again i heard a tapping something louder than before
        surely said i surely that is something at my window lattice
        let me see then what thereat is and this mystery explore
        let my heart be still a moment and this mystery explore
        tis the wind and nothing more

        open here i flung the shutter when with many a flirt and flutter
        in there stepped a stately raven of the saintly days of yore
        not the least obeisance made he not a minute stopped or stayed he
        but with mien of lord or lady perched above my chamber door
        perched upon a bust of pallas just above my chamber door
        perched and sat and nothing more

        then the ebony bird beguiling my sad fancy into smiling
        by the grave and stern decorum of the countenance it wore
        though thy crest be shorn and shaven thou i said art sure no craven
        ghastly grim and ancient raven wandering from the nightly shore
        tell me what thy lordly name is on the nights plutonian shore
        quoth the raven nevermore

        much i marvelled this ungainly fowl to hear discourse so plainly
        though its answer little meaninglittle relevancy bore
        for we cannot help agreeing that no living human being
        ever yet was blessed with seeing bird above his chamber door
        bird or beast upon the sculptured bust above his chamber door
        with such name as nevermore

        but the raven sitting lonely on that placid bust spoke only
        that one word as if its soul in that one word he did outpour
        nothing farther then he uttered not a feather then he fluttered
        till i scarcely more than muttered other friends have flown before
        on the morrow he will leave me as my hopes have flown before
        then the bird said nevermore

        startled at the stillness broken by reply so aptly spoken
        doubtless said i what it utters is its only stock and store
        caught from some unhappy master whom unmerciful disaster
        followed fast and followed faster till his songs one burden bore
        till the dirges of his hope that melancholy burden bore
        of nevernevermore

        but the raven still beguiling all my sad soul into smiling
        straight i wheeled a cushioned seat in front of bird and bust and door
        then upon the velvet sinking i betook myself to linking
        fancy unto fancy thinking what this ominous bird of yore
        what this grim ungainly ghastly gaunt and ominous bird of yore
        meant in croaking nevermore

        this i sat engaged in guessing but no syllable expressing
        to the fowl whose fiery eyes now burned into my bosoms core
        this and more i sat divining with my head at ease reclining
        on the cushions velvet lining that the lamplight gloated oer
        but whose velvet violet lining with the lamplight gloating oer
        she shall press ah nevermore

        then methought the air grew denser perfumed from an unseen censer
        swung by seraphim whose footfalls tinkled on the tufted floor
        wretch i cried thy god hath lent theeby these angels he hath sent thee
        respiterespite and nepenthe from thy memories of lenore
        quaff oh quaff this kind nepenthe and forget this lost lenore
        quoth the raven nevermore

        prophet said i thing of evilprophet still if bird or devil
        whether tempter sent or whether tempest tossed thee here ashore
        desolate yet all undaunted on this desert land enchanted
        on this home by horror hauntedtell me truly i implore
        is thereis there balm in gileadtell metell me i implore
        quoth the raven nevermore

        prophet said i thing of evilprophet still if bird or devil
        by that heaven that bends above usby that god we both adore
        tell this soul with sorrow laden if within the distant aidenn
        it shall clasp a sainted maiden whom the angels name lenore
        clasp a rare and radiant maiden whom the angels name lenore
        quoth the raven nevermore

        be that our sign of parting bird or fiend i shrieked upstarting
        get thee back into the tempest and the nights plutonian shore
        leave no black plume as a token of that lie thy soul has spoken
        leave my loneliness unbrokenquit the bust above my door
        take thy beak from out my heart and take thy form from off my door
        quoth the raven nevermore

        and the raven never flitting still is sitting still is sitting
        on the pallid bust of pallas just above my chamber door
        and his eyes have all the seeming of a demons that is dreaming
        and the lamplight oer him streaming throws his shadows on the floor
        and my soul from out that shadow that lies floating on the floor
        shall be lifted nevermore";

        /// <summary>
        /// Ómagyar-Mária siralom - Ismeretlen
        /// </summary>
        /// <remarks>This text is under public domain</remarks>
        static readonly string Siralom = @"volek syrolm thudothlon syrolmol sepedyk buol ozuk epedek walasth vylagumtul
        sydou fyodumtul ezes urumemtuul o en eses urodum eggen yg fyodum syrou aniath
        thekunched buabeleul kyniuhhad scemem kunuel arad en iunhum buol farad the
        werud hullothya en iunhum olelothya vylag uilaga viragnac uiraga keseruen
        kynzathul uos scegegkel werethul vh nequem en fyon ezes mezuul scegenul
        scepsegud wirud hioll wyzeul syrolmom fuhazatum therthetyk kyul en iumhumnok
        bel bua qui sumha nym kyul hyul wegh halal engumet eggedum illen maraggun
        urodum kyth wylag felleyn o ygoz symeonnok bezzeg scouuo ere en erzem ez
        buthuruth kyt niha egyre tuled ualmun de num ualallal hul yg kynzassal fyom
        halallal sydou myth thez turuentelen fyom merth hol byuntelen fugwa huztuzwa
        wklelue kethwe ulud keguggethuk fyomnok ne leg kegulm mogomnok owog halal
        kynaal anyath ezes fyaal egembelu ullyetuk";

        /// <summary>
        /// Hemsöborna - August Strindberg (1912-1921)
        /// </summary>
        /// <remarks>This text is under public domain</remarks>
        static readonly string Strindberg = @"han kom som ett yrväder en aprilafton och hade
        ett höganäskrus i en svångrem om halsen clara
        och lotten voro inne med skötekan att hämta
        honom på dalarö brygga men det dröjde evigheter
        innan de kommo i båt de skulle till handelsman
        och ha en tunna tjära och på abeteket och hämta
        gråsalva åt grisen och så skulle de på posten och
        få ett frimärke och så skulle de ner till fia lövström
        i kroken och låna tuppen mot ett halvpund
        småtärna till notbygget och sist hade de hamnat på
        gästgivaregården där carlsson bjudit på kaffe med
        dopp och så kommo de äntligen i båt men carlsson
        ville styra och det kunde han inte för han hade
        aldrig sett en råseglare förr och därför skrek han
        att de skulle hissa focken som inte fanns

        och på tullbryggan stodo lotsar och vaktmästare
        och grinade åt manövern när ekan gick över stag
        och länsade ner åt saltsäcken

        hörru du har hål i båten skrek en lotslärling
        genom vinden stopp till stopp till och medan
        carlsson tittade efter hålen hade clara knuffat
        undan honom och tagit roret och med årorna lyckades
        lotten få ekan opp i vinden igen så att nu strök
        det ner åt aspösund med god gång

        carlsson var en liten fyrkantig värmländing med
        blå ögon och näsa krokig som en syskonhake livlig
        lekfull och nyfiken var han men sjöaffärerna förstod
        han inte alls och han var också kallad ut till
        hemsö för att ta hand om åker och kreatur som
        ingen annan ville ta befattning med sedan gubben
        flod gått ur livet och änkan satt ensam vid gården";

        #endregion Fields
    }
}